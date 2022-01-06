using ZarinSharp.Responses;

namespace ZarinSharp
{
    public static class ResponsesExtensions
    {
        /// <summary>
        /// Gets start payment url from a <see cref="ZarinpalPaymentRequestRespond"/>.
        /// </summary>
        /// <remarks>The customer should use this to do payment stuff.</remarks>
        /// <param name="isSandbox">If its a sandbox request.</param>
        public static string GetStartPaymentUrl(
            this ZarinpalPaymentRequestRespond response,
            bool? isSandbox = false) => ZarinpalUrlConfig.GetPaymenGatewayUrl(
                response.Authority, isSandbox);

        /// <summary>
        /// Ensures the payment request was successful.
        /// Throw an exception of type <see cref="ZarinpalException"/> if not.
        /// </summary>
        /// <exception cref="ZarinpalException"></exception>
        public static void EnsureSuccess(
            this ZarinpalPaymentRequestRespond response)
        {
            if (response.Code != 100 || string.IsNullOrEmpty(response.Authority))
                throw new ZarinpalException(response.Code, response.Message);
        }

        /// <summary>
        /// Ensures a payment is verified. for first time only.
        /// </summary>
        public static void EnsureVerified(
            this ZarinpalVerifyResponse response)
        {
            if (response.Code != 100)
                throw new ZarinpalException(response.Code, response.Message);
        }

        /// <summary>
        /// Ensures a payment is verified. for first time or not.
        /// </summary>
        /// <param name="response"></param>
        public static void EnsureVerifiedOrDuplicated(
            this ZarinpalVerifyResponse response)
        {
            if (response.Code != 100 || response.Code != 101)
                throw new ZarinpalException(response.Code, response.Message);
        }
    }
}