using System.Text.Json.Serialization;
using ZarinSharp.Types;

namespace ZarinSharp.Responses
{
    /// <summary>
    /// A response from zarinpal
    /// </summary>
    /// <typeparam name="T">Response data</typeparam>
    public class ResponseBase<T>
    {
        /// <summary>
        /// The data of the response
        /// </summary>
        [JsonPropertyName("data")]
        public T? Data { get; set; }

        /// <summary>
        /// A collection of error codes. should be empty here.
        /// </summary>
        [JsonPropertyName("errors")]
        public IEnumerable<ZarinpalError> Errors { get; set; } = Enumerable.Empty<ZarinpalError>();
    }
}
