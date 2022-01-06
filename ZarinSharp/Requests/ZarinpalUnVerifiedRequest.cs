using System.Text.Json.Serialization;
using ZarinSharp.Responses;

namespace ZarinSharp.Requests
{
    /// <summary>
    /// Represents a request to get 100 last unverified payments
    /// </summary>
    public class ZarinpalUnVerifiedRequest :
        RequestBase<ResponseBase<ZarinpalUnVerifiedResponse>>
    {
        /// <summary>
        /// Represents a request to get 100 last unverified payments
        /// </summary>
        /// <param name="merchantId">Your MerchantId or Token from <see href="https://next.zarinpal.com"/>.</param>
        public ZarinpalUnVerifiedRequest(string merchantId): base("unVerified.json")
        {
            MerchantId = merchantId;
        }

        /// <summary>
        /// Your MerchantId or Token from <see href="https://next.zarinpal.com"/>.
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; }
    }
}
