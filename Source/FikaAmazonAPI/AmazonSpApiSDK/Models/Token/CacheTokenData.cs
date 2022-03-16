using System;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Token
{
    public class CacheTokenData
    {
        protected TokenResponse NormalAccessToken { get; set; }
        protected TokenResponse PIIAccessToken { get; set; }
        protected TokenResponse GrantlessAccessToken { get; set; }
        protected AWSAuthenticationTokenData AWSAuthenticationTokenData { get; set; }

        public AWSAuthenticationTokenData GetAWSAuthenticationTokenData()
        {
            if (AWSAuthenticationTokenData != null && AWSAuthenticationTokenData.Expiration.AddSeconds(-60) > DateTime.Now)
                return AWSAuthenticationTokenData;
            else return null;
        }
        public void SetAWSAuthenticationTokenData(AWSAuthenticationTokenData tokenData)
        {
            AWSAuthenticationTokenData = tokenData;
        }
        public TokenResponse GetToken(TokenDataType tokenDataType)
        {
            TokenResponse token = null;
            if (tokenDataType == TokenDataType.Normal)
            {
                token = NormalAccessToken;
            }
            else if (tokenDataType == TokenDataType.PII)
            {
                token = PIIAccessToken;
            }
            else if (tokenDataType == TokenDataType.Grantless)
            {
                token = GrantlessAccessToken;
            }
            if (token == null)
                return null;
            else
            {
                var isExpired = IsTokenExpired(token.expires_in, token.date_Created);
                if (!isExpired)
                    return token;
                else return null;
            }
        }

        public void SetToken(TokenDataType tokenDataType, TokenResponse token)
        {

            if (tokenDataType == TokenDataType.Normal)
            {
                NormalAccessToken = token;
            }
            else if (tokenDataType == TokenDataType.PII)
            {
                //its not true to save PII token and reuse it with other request
                //PIIAccessToken=token;
            }
            else if (tokenDataType == TokenDataType.Grantless)
            {
                GrantlessAccessToken = token;
            }
        }

        public enum TokenDataType
        {
            Normal,
            PII,
            Grantless
        }


        public static bool IsTokenExpired(int? expiresIn, DateTime? dateCreated)
        {
            if (dateCreated == null)
                return false;
            else
                return DateTime.UtcNow.Subtract((DateTime)dateCreated).TotalSeconds > (expiresIn - 60); //Add Margent to a void expaired token
        }
    }


}
