using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace ZarinSharp.Types.Tests
{
    [TestClass()]
    public class AuthorityInfoTests
    {
        [TestMethod()]
        public void AuthorityInfoTest()
        {
            var jsonString = @"
{
    ""authority"": ""A00000000000000000000000000207288780"",
    ""amount"": 50500,
    ""callback_url"": ""https://golroz.com/vpay"",
    ""referer"": ""https://golroz.com/test-form/"",
    ""date"": ""2020-07-01 17:33:25""
}";
            var obj = JsonSerializer.Deserialize<AuthorityInfo> (
                jsonString, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });
            System.Console.WriteLine();
        }

        [TestMethod()]
        public void AuthorityInfoTest_2()
        {
            var obj = JsonSerializer.Serialize<AuthorityInfo>(
                new AuthorityInfo(
                    "A00000000000000000000000000207288780",
                    50500,
                    "https://golroz.com/vpay",
                    "https://golroz.com/test-form/",
                    System.DateTime.UtcNow),
                new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });
            System.Console.WriteLine();
        }
    }
}