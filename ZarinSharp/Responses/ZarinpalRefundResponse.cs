using System.Text.Json.Serialization;

namespace ZarinSharp.Responses
{
    public class ZarinpalRefundResponse : IZarinpalResponseData
    {
        [JsonConstructor]
        public ZarinpalRefundResponse(int code, string message, long refId, long session, string shabaNumber)
        {
            Code = code;
            Message = message;
            RefId = refId;
            Session = session;
            ShabaNumber = shabaNumber;
        }

        [JsonPropertyName("code")]
        public int Code { get; }

        [JsonPropertyName("message")]
        public string Message { get; }

        /// <summary>
        /// Reference id of refund operation.
        /// </summary>
        [JsonPropertyName("ref_id")]
        public long RefId { get; }

        /// <summary>
        /// Session id.
        /// </summary>
        [JsonPropertyName("session")]
        public long Session { get; }

        /// <summary>
        /// Shaba number where refunded to.
        /// </summary>
        [JsonPropertyName("iban")]
        public string ShabaNumber { get; }
    }
}
