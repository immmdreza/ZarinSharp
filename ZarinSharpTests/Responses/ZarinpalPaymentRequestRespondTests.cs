using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace ZarinSharp.Responses.Tests
{
    [TestClass()]
    public class ZarinpalPaymentRequestRespondTests
    {
        [TestMethod()]
        public void ZarinpalPaymentRequestRespondTest()
        {
            var jsonString = @"
{
    ""code"": 100,
    ""message"": ""Success"",
    ""authority"": ""A00000000000000000000000000217885159"",
    ""fee_type"": ""Merchant"",
    ""fee"": 100
}";

            var obj = JsonSerializer.Deserialize<ZarinpalPaymentRequestRespond>(
                jsonString, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });
            System.Console.WriteLine();
        }
    }
}