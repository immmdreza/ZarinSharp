﻿using System.Text.Json.Serialization;
using ZarinSharp.Types;

namespace ZarinSharp.Responses
{
    /// <summary>
    /// Represents a response to verify request.
    /// </summary>
    public class ZarinpalVerifyResponse
    {
        [JsonConstructor]
        public ZarinpalVerifyResponse(
            int code,
            string message,
            string cardHash,
            string cardPan,
            long refId,
            string feeType,
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

        /// <summary>
        /// Response code in number
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// The message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// SHA256 hash of card number.
        /// </summary>
        [JsonPropertyName("card_hash")]
        public string CardHash { get; set; }

        /// <summary>
        /// Masked card number
        /// </summary>
        [JsonPropertyName("card_pan")]
        public string CardPan { get; set; }

        /// <summary>
        /// The reference id of this payment
        /// </summary>
        [JsonPropertyName("ref_id")]
        public long RefId { get; set; }

        /// <summary>
        /// The type of fee payment - could be the Merchant or Customer
        /// </summary>
        [JsonPropertyName("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// Fee amount
        /// </summary>
        [JsonPropertyName("fee")]
        public long Fee { get; set; }

        /// <summary>
        /// Optional. Information about a wages payment request.
        /// </summary>
        [JsonPropertyName("wages")]
        public IEnumerable<WageInfo>? Wages { get; set; }
    }
}
