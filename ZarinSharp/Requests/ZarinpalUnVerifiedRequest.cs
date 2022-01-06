using System.Text.Json.Serialization;
using ZarinSharp.Responses;

namespace ZarinSharp.Requests
{
    public class ZarinpalUnVerifiedRequest :
        RequestBase<ResponseBase<ZarinpalUnVerifiedResponse>>
    {
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
