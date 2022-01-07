using System.Collections.Generic;
using System.Text.Json.Serialization;
using ZarinSharp.Converters;
using ZarinSharp.Types;
using ZarinSharp.Types.Enums;

namespace ZarinSharp.Responses
{
    /// <summary>
    /// Represents a response to verify request.
    /// </summary>
    public class ZarinpalVerifyResponse : IZarinpalResponseData
    {
        [JsonConstructor]
        public ZarinpalVerifyResponse(
            int code,
            string message,
            string cardHash,
            string cardPan,
            long refId,
            FeeType feeType,
            long fee,
            IEnumerable<WageInfo>? wages = default)
        {
            Code = code;
            Message = message;
            CardHash = cardHash;
            CardPan = cardPan;
            RefId = refId;
            FeeType = feeType;
            Fee = fee;
            Wages = wages;
        }

        [JsonPropertyName("code")]
        public int Code { get; }

        [JsonPropertyName("message")]
        public string Message { get; }

        /// <summary>
        /// SHA256 hash of card number.
        /// </summary>
        [JsonPropertyName("card_hash")]
        public string CardHash { get; }

        /// <summary>
        /// Masked card number
        /// </summary>
        [JsonPropertyName("card_pan")]
        public string CardPan { get; }

        /// <summary>
        /// The reference id of this payment
        /// </summary>
        [JsonPropertyName("ref_id")]
        public long RefId { get; }

        /// <summary>
        /// The type of fee payment - could be the Merchant or Customer
        /// </summary>
        [JsonPropertyName("fee_type")]
        [JsonConverter(typeof(FeeTypeConverter))]
        public FeeType FeeType { get; }

        /// <summary>
        /// Fee amount
        /// </summary>
        [JsonPropertyName("fee")]
        public long Fee { get; }

        /// <summary>
        /// Optional. Information about a wages payment request.
        /// </summary>
        [JsonPropertyName("wages")]
        public IEnumerable<WageInfo>? Wages { get; }
    }
}
