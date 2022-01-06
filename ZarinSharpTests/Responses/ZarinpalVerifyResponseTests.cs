using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace ZarinSharp.Responses.Tests
{
    [TestClass()]
    public class ZarinpalVerifyResponseTests
    {
        [TestMethod()]
        public void ZarinpalVerifyResponseTest()
        {
            var jsonString = @"
{
    ""data"": {
        ""code"": 100,
        ""message"": ""Paid"",
        ""card_hash"": ""16A8E235A8C6047574D413008DB1FC9D51A44E3D37C83BAFC6491A72B696D4541FE77F7B057E884A9F5BD101F477C4B22990C1FC833FEB79DDAE9C6F56BE889B"",
        ""card_pan"": ""502229******8920"",
        ""ref_id"": 21790905701,
        ""fee_type"": ""Merchant"",
        ""fee"": 0
    },
    ""errors"": []
    }
";
            var obj = JsonSerializer.Deserialize<ResponseBase<ZarinpalVerifyResponse>>(
                jsonString, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });
            System.Console.WriteLine();
        }

        [TestMethod()]
        public void ZarinpalVerifyResponse_WagesTest()
        {
            var jsonString = @"
{
    ""data"": {
        ""wages"": [
            {
                ""iban"": ""IR130570028780010957775103"",
                ""amount"": 1000,
                ""description"": ""تسهیم سود فروش از محصول به مسعود امینی""
            },
            {
                ""iban"": ""IR670170000000352965862009"",
                ""amount"": 5000,
                ""description"": ""تسهیم سود فروش از محصول به یوسفی""
            }
        ],
        ""code"": 100,
        ""message"": ""Paid"",
        ""card_hash"": ""16A8E235A8C6047574D413008DB1FC9D51A44E3D37C83BAFC6491A72B696D4541FE77F7B057E884A9F5BD101F477C4B22990C1FC833FEB79DDAE9C6F56BE889B"",
        ""card_pan"": ""502229******8920"",
        ""ref_id"": 21790905701,
        ""fee_type"": ""Merchant"",
        ""fee"": 0
    },
    ""errors"": []
    }
";
            var obj = JsonSerializer.Deserialize<ResponseBase<ZarinpalVerifyResponse>>(
                jsonString, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });
            System.Console.WriteLine();
        }
    }
}