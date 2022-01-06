using System.Text.Json.Serialization;

namespace ZarinSharp.Types
{
    public class AuthorityInfo
    {
        [JsonConstructor]
        public AuthorityInfo(string authority, long amount, string callbackUrl, string referer, string date)
        {
            Authority = authority;
            Amount = amount;
            CallbackUrl = callbackUrl;
            Referer = referer;
            Date = date;
        }

        [JsonPropertyName("authority")]
        public string Authority { get; }

        [JsonPropertyName("amount")]
        public long Amount { get; }

        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; }

        [JsonPropertyName("referer")]
        public string Referer { get; }

        [JsonPropertyName("date")]
        public string Date { get; }
    }
}
