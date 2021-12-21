using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Parameter
{
    public interface IHasParameterizedTestCase
    {
        string TestCase { get; set; }
        Dictionary<string, List<KeyValuePair<string, string>>> SandboxQueryParameters { get; }
    }
}
