using System.Text.Json.Serialization;

namespace ZarinSharp.Types
{
    /// <summary>
    /// A request failed and here is the info returned by zarinpal
    /// </summary>
    public class ZarinpalError
    {
        /// <summary>
        /// Error code
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// A list of required validations
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, List<string?>>? Validations { get; set; }
    }
}
