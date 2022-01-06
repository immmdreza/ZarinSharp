using System.Text.Json.Serialization;

namespace ZarinSharp.Responses
{
    /// <summary>
    /// Represents a response to a payment request
    /// </summary>
    public class ZarinpalPaymentRequestRespond
    {
        [JsonConstructor]
        public ZarinpalPaymentRequestRespond(
            int code, string message, string authority, string feeType, long fee)
        {
            Code = code;
            Message = message;
            Authority = authority;
            FeeType = feeType;
            Fee = fee;
        }

        /// <summary>
        /// Response code in number
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; }

        /// <summary>
        /// The message.
        /// </summary>
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
        public string FeeType { get; }

        /// <summary>
        /// Fee amount
        /// </summary>
        [JsonPropertyName("fee")]
        public long Fee { get; }
    }
}
