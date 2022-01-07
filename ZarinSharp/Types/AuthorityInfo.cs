using System;
using System.Text.Json.Serialization;
using ZarinSharp.Converters;

namespace ZarinSharp.Types
{
    public class AuthorityInfo
    {
        [JsonConstructor]
        public AuthorityInfo(string authority, long amount, string callbackUrl, string referer, DateTime date)
        {
            Authority = authority;
            Amount = amount;
            CallbackUrl = callbackUrl;
            Referer = referer;
            Date = date;
        }

        /// <summary>
        /// Unique identifier of the payment.
        /// </summary>
        [JsonPropertyName("authority")]
        public string Authority { get; }

        /// <summary>
        /// Amount of the payment.
        /// </summary>
        [JsonPropertyName("amount")]
        public long Amount { get; }

        /// <summary>
        /// Callback url of the payment.
        /// </summary>
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; }

        /// <summary>
        /// The referer.
        /// </summary>
        [JsonPropertyName("referer")]
        public string Referer { get; }

        /// <summary>
        /// The date when payment made.
        /// </summary>
        [JsonPropertyName("date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime Date { get; }
    }
}
