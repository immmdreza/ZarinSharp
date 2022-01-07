using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using ZarinSharp.Types;

namespace ZarinSharp.Responses
{
    /// <summary>
    /// The requests was unsuccessful.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnsuccessResponseBase<T>
    {
        [JsonConstructor]
        public UnsuccessResponseBase(IEnumerable<T> data, ZarinpalError error)
        {
            Data = data;
            Error = error;
        }

        /// <summary>
        /// The data. should be empty here.
        /// </summary>
        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();

        /// <summary>
        /// Error
        /// </summary>
        [JsonPropertyName("errors")]
        public ZarinpalError Error { get; set; }
    }
}
