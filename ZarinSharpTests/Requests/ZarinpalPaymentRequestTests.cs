using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZarinSharp.Types;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using ZarinSharp.Types.Enums;

namespace ZarinSharp.Requests.Tests
{
    [TestClass()]
    public class ZarinpalPaymentRequestTests
    {
        [TestMethod()]
        public void ZarinpalPaymentRequest_WagesTest()
        {
            var request = new ZarinpalPaymentRequest(
                "1344b5d4-0048-11e8-94db-005056a205be",
                20000,
                "http://yoursite.com/verify",
                "Transaction description.")
            {
                Metadata = new CustomerInfo("091212334567", "info.test@gmail.com"),
                Wages = new WageInfo[]
                {
                    new WageInfo("IR130570028780010957775103", 1000, "تسهیم سود فروش از محصول به مسعود امینی"),
                    new WageInfo("IR670170000000352965862009", 5000, "تسهیم سود فروش از محصول به یوسفی")
                }
            };

            var exceptedJson = @"
{
    ""merchant_id"": ""1344b5d4-0048-11e8-94db-005056a205be"",
    ""amount"": 20000,
    ""callback_url"": ""http://yoursite.com/verify"",
    ""description"": ""Transaction description."",
    ""metadata"": 
    {
        ""mobile"": ""091212334567"",
        ""email"": ""info.test@gmail.com""
    },
    ""wages"":
    [
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
    ]
}";
            var seialized = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            });
            Assert.AreEqual(exceptedJson, seialized);
        }

        [TestMethod()]
        public void ZarinpalPaymentRequest_CurrencyTest()
        {
            var req = new ZarinpalPaymentRequest(
                "1344b5d4-0048-11e8-94db-005056a205be",
                20000,
                "www.url.com",
                "description")
            {
                Currency = Currency.IRT
            };

            var seialized = JsonSerializer.Serialize(req, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            });
            System.Console.WriteLine();
        }
    }
}