using System.Text.Json.Serialization;
using ZarinSharp.Responses;

namespace ZarinSharp.Requests
{
    /// <summary>
    /// Represents a request to refund a payment
    /// </summary>
    public class ZarinpalRefundRequest
        : RequestBase<ResponseBase<ZarinpalRefundResponse>>,
        IRequireAuthorization
    {
        /// <summary>
        /// Represents a request to refund a payment
        /// </summary>
        /// <param name="merchantId">Your MerchantId or Token from <see href="https://next.zarinpal.com"/>.</param>
        /// <param name="authority">The authority, which is unique per payment.</param>
        /// <param name="accessToken">Access token required to invoke this request.</param>
        public ZarinpalRefundRequest(
            string merchantId,
            string authority,
            string accessToken) : base("refund.json")
        {
            MerchantId = merchantId;
            Authority = authority;
            AccessToken = accessToken;
        }

        /// <summary>
        /// Your MerchantId or Token from <see href="https://next.zarinpal.com"/>.
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// The authority, which is unique per payment.
        /// </summary>
        [JsonPropertyName("authority")]
        public string Authority { get; }

        public string AccessToken { get; }
    }
}
