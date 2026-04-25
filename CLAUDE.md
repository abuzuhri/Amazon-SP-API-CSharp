# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository overview

`CSharpAmazonSpAPI` (NuGet id) / `FikaAmazonAPI` (assembly) — a .NET binding for Amazon's Selling Partner (SP) API. The SDK code is largely generated from Amazon's swagger/OpenAPI models (https://github.com/amzn/selling-partner-api-models) and then wrapped with hand-written `*Service` classes that handle auth, rate limiting, paging, and PII (Restricted Data Token) flows.

## Solution layout

`Amazon-SP-API-CSharp.sln` contains three buildable projects under `Source/`:

- **`FikaAmazonAPI/`** — the shipping library, `netstandard2.0`. This is the only thing that gets packed/published.
- **`FikaAmazonAPI.SampleCode/`** — `net6.0` console app with one `*Sample.cs` per API surface. Treat this as the live usage documentation; when adding/changing public methods, update the matching sample.
- **`Tests/`** — `net6.0` NUnit project. Currently only `RateLimitsTests.cs`. The library exposes `internal` members to it via `[assembly: InternalsVisibleTo("Tests")]` (see `Utils/RateLimits.cs`).

`Source/RestSharp/` is **not** a project — it's a vendored fork of RestSharp. `FikaAmazonAPI.csproj` glob-includes it via `<Compile Include="..\RestSharp\*.cs" />`. Don't add a project reference; edits there compile straight into the library.

## Build / test / pack

```bash
dotnet restore
dotnet build                                              # builds all three projects
dotnet build ./Source/FikaAmazonAPI/FikaAmazonAPI.csproj --configuration Release
dotnet test  ./Source/Tests/Tests.csproj                  # NUnit suite (rate-limit tests only)
dotnet test  ./Source/Tests/Tests.csproj --filter "FullyQualifiedName~WaitForPermittedRequest"   # single test
dotnet pack  ./Source/FikaAmazonAPI/FikaAmazonAPI.csproj  --configuration Release   # produces .nupkg
```

CI (`.github/workflows/dotnet.yml`) runs `dotnet restore` + `dotnet build --no-restore` on `ubuntu-latest` with .NET 6 — there is no test step in CI. `nuget.yml` publishes the package on tags matching `v*.*.*` or `*.*.*` (and `-rc*` variants); bump `<Version>` / `<AssemblyVersion>` / `<FileVersion>` in `FikaAmazonAPI.csproj` together when releasing.

## Architecture

### Entry point — `AmazonConnection`

`AmazonConnection` (constructed with an `AmazonCredential`) is the user-facing facade. Its constructor eagerly instantiates one `*Service` per API (`Orders`, `Reports`, `Feed`, `FbaInventory`, …) and exposes them as properties. To add a new API surface, you must touch **three** places in `AmazonConnection.cs`: the public property, the private backing field, and the `Init(...)` initialization. `ValidateCredentials` enforces ClientId/ClientSecret/RefreshToken presence and resolves `MarketPlaceID` → `MarketPlace` if only the ID was supplied.

AWS IAM (AccessKey/SecretKey/RoleArn/STS request signing) is no longer required — that branch is commented out throughout (`AmazonConnection.ValidateCredentials`, `RequestService.ExecuteRequestTry`). Don't reintroduce it without a clear reason; LWA refresh-token auth is the supported path.

### Service base — `Services/RequestService`

Every `*Service` inherits `RequestService : ApiUrls`. The lifecycle of a single SP-API call is:

1. `CreateAuthorizedRequestAsync(url, method, queryParameters, postJsonObj, tokenDataType, parameter)` — refreshes the LWA access token (or a Restricted Data Token if the parameter implements `IParameterBasedPII` and `IsNeedRestrictedDataToken == true`), then constructs the `RestRequest`.
2. `ExecuteRequestAsync<T>(rateLimitType)` wraps `ExecuteRequestTry<T>` in a retry loop bounded by `AmazonCredential.MaxThrottledRetryCount` (default 3) on `AmazonQuotaExceededException`.
3. After each response, headers are stashed in `LastHeaders`, and `SleepForRateLimit` updates the per-operation `RateLimits` bucket.

The base URL switches on `AmazonCredential.Environment` (`Sandbox` vs `Production`) via `MarketPlace.Region.SandboxHostUrl` / `HostUrl`. `RestClient` is constructed per-request with `RestClientOptions { Proxy = AmazonCredential.Proxy }` and `UseNewtonsoftJson()` — `IWebProxy` flows from credentials all the way down.

### Rate limiting — `Utils/RateLimits` + `RateLimitType`

Per-operation token-bucket limiter. `RateLimitsDefinitions.RateLimitsTime()` populates a `Dictionary<RateLimitType, RateLimits>` on each `AmazonCredential`. Services pass a `RateLimitType` enum value (e.g. `RateLimitType.Order_GetOrders`) into `ExecuteRequestAsync`. When adding a new endpoint, add a `RateLimitType` enum entry and register its rate/burst in `RateLimitsDefinitions`. Set `AmazonCredential.IsActiveLimitRate = false` to disable.

### Parameters and PII / RDT flow

Request params live under `Parameter/<Domain>/Parameter*.cs` and typically derive from `ParameterBased` (with attributes `[CamelCase]`, `[PathParameter]`, `[BodyParameter]`, `[IgnoreToAddParameter]` controlling how `getParameters()` serializes them).

Anything carrying buyer PII derives from `ParameterBasedPII` and implements `IParameterBasedPII`. When the caller sets `IsNeedRestrictedDataToken = true`, the service builds a `CreateRestrictedDataTokenRequest` (see `OrderService.GetOrdersAsync` for the canonical example — it lists `dataElements = ["buyerInfo", "shippingAddress"]`) and `RequestService` swaps the normal LWA token for an RDT before the call. See `PII_QA.md` for the user-facing rules.

### Singleton HttpClient

`AmazonSpApiSDK/Runtime/RestClientSingleton` keeps one process-wide `HttpClient` backed by `StandardSocketsHttpHandler` with `PooledConnectionLifetime = 1 minute` to fix the socket-leak in issue #523. Because the library targets `netstandard2.0`, the framework `SocketsHttpHandler` isn't available, so the `StandardSocketsHttpHandler` NuGet (a backport) is used to expose `PooledConnectionLifetime` on .NET Framework consumers.

### Convention: every public method is sync + async

Each service method comes in a pair, e.g.

```csharp
public OrderList GetOrders(ParameterOrderList p) =>
    Task.Run(() => GetOrdersAsync(p)).ConfigureAwait(false).GetAwaiter().GetResult();
public async Task<OrderList> GetOrdersAsync(ParameterOrderList p, CancellationToken ct = default) { ... }
```

Keep this pattern for any new method. Real work belongs in the `*Async` overload; the sync wrapper just blocks on it.

### Paging convention

Methods that page (`GetOrders`, listings, reports, …) loop on `NextToken` internally and concatenate results. Honor `parameter.MaxNumberOfPages` if the parameter exposes it; when `MaxNumberOfPages == 1`, return the first page and surface `NextToken` on the result so callers can continue manually.

### Marketplace + region

`Utils/MarketPlace` is a curated list of static instances (`MarketPlace.UnitedArabEmirates`, etc.) each pointing to a `Region` with `HostUrl` / `SandboxHostUrl`. Callers either set `MarketPlace` directly or supply `MarketPlaceID` and let `ValidateCredentials` resolve it via `MarketPlace.GetMarketPlaceByID(...)`.

### Generated SDK area

`AmazonSpApiSDK/Models/<Domain>/` is mostly swagger-generated DTOs — when Amazon updates their OpenAPI spec, these get regenerated/overwritten. Avoid hand-editing these files; behavior changes belong in `Services/*Service.cs` or `Parameter/*` instead. `AmazonSpApiSDK/Models/Exceptions/` holds the `Amazon*Exception` hierarchy (e.g. `AmazonQuotaExceededException`, `AmazonUnauthorizedException`, `AmazonInvalidInputException`) — these are the exceptions services throw, and `RequestService.ExecuteRequestAsync` retries on `AmazonQuotaExceededException`.

## Adding a new SP-API operation — checklist

1. Add request DTO under `Parameter/<Domain>/Parameter<Op>.cs` (extend `ParameterBased` or `ParameterBasedPII`).
2. Add response/model DTOs under `AmazonSpApiSDK/Models/<Domain>/` (often regenerated from Amazon's swagger).
3. Add the URL template constant to `Services/ApiUrls.cs` (or the matching domain partial).
4. Add `RateLimitType.<Domain>_<Op>` and its rate/burst in `Utils/RateLimitsDefinitions`.
5. Add the sync + async pair to the relevant `Services/*Service.cs`.
6. Add a usage example to `FikaAmazonAPI.SampleCode/<Domain>Sample.cs`.
7. If the response contains buyer PII, make the request DTO implement `IParameterBasedPII` and pass it through as `parameter:` to `CreateAuthorizedRequestAsync`.
