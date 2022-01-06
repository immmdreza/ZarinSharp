using System.Text.Json.Serialization;
using ZarinSharp.Responses;

namespace ZarinSharp.Requests
{
    /// <summary>
    /// Request to verify the status of a payment.
    /// </summary>
    public class ZarinpalVerifyRequest
        : RequestBase<ResponseBase<ZarinpalVerifyResponse>>
    {
        /// <summary>
        /// Your MerchantId or Token from <see href="https://next.zarinpal.com"/>
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// The amount of payment
        /// </summary>
        [JsonPropertyName("amount")]
        public long Amount { get; }

        /// <summary>
        /// The authority, which is unique per payment.
        /// </summary>
        [JsonPropertyName("authority")]
        public string Authority { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="amount"></param>
        /// <param name="authority"></param>
        public ZarinpalVerifyRequest(
            string merchantId,
            long amount,
            string authority) : base("verify.json")
        {
            merchantId.ThrowIfNull(nameof(merchantId));
            authority.ThrowIfNull(nameof(authority));
            if (amount < 1000)
                throw new ZarinpalException(501, "Amount can't be less than 1000!");

            Amount = amount;
            Authority = authority;
            MerchantId = merchantId;
        }
    }
}
