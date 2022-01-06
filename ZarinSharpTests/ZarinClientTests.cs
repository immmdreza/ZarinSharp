using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using ZarinSharp.Types;

namespace ZarinSharp.Tests
{
    [TestClass]
    public class ZarinClientTests
    {
        private readonly ZarinClient zarinClient;

        public ZarinClientTests()
        {
            var configs = new ZarinpalConfiguration(
                "TOKEN",
                "CALLBACK_URL");

            zarinClient = new ZarinClient(configs);
        }

        [TestMethod]
        public async Task ZarinClient_PayTest()
        {
            var paymentRequestRespond = await zarinClient.PaymentRequestAsync(
                2000,
                "A simple payment request test.",
                new CustomerInfo(email: "example@email.com"));

            var getway = paymentRequestRespond.GetStartPaymentUrl();
        }

        [TestMethod]
        public async Task ZarinClient_VerifyTest()
        {
            string authority = "A000000000000000000000000001234567";

            var verifyResponse = await zarinClient.VerifyPaymentAsync(2000, authority);

            Console.WriteLine();
        }
    }
}