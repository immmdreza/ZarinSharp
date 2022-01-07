using System.Text.Json.Serialization;
using ZarinSharp.Converters;
using ZarinSharp.Types.Enums;

namespace ZarinSharp.Responses
{
    /// <summary>
    /// Represents a response to a payment request
    /// </summary>
    public class ZarinpalPaymentRequestRespond: IZarinpalResponseData
    {
        [JsonConstructor]
        public ZarinpalPaymentRequestRespond(
            int code, string message, string authority, FeeType feeType, long fee)
        {
            Code = code;
            Message = message;
            Authority = authority;
            FeeType = feeType;
            Fee = fee;
        }

        [JsonPropertyName("code")]
        public int Code { get; }

        [JsonPropertyName("message")]
        public string Message { get; }

        /// <summary>
        /// Unique identifier for this payment
        /// </summary>
        [JsonPropertyName("authority")]
        public string Authority { get; }

        /// <summary>
        /// The type of fee payment - Could be the Merchant or Customer
        /// </summary>
        [JsonPropertyName("fee_type")]
        [JsonConverter(typeof(FeeTypeConverter))]
        public FeeType FeeType { get; }

        /// <summary>
        /// Fee amount
        /// </summary>
        [JsonPropertyName("fee")]
        public long Fee { get; }
    }
}
