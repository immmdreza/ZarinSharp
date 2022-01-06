using System.Text.Json.Serialization;
using ZarinSharp.Types;

namespace ZarinSharp.Responses
{
    public class ZarinpalUnVerifiedResponse : IZarinpalResponseData
    {
        [JsonConstructor]
        public ZarinpalUnVerifiedResponse(int code, string message, IEnumerable<AuthorityInfo> authorities)
        {
            Code = code;
            Message = message;
            Authorities = authorities;
        }

        [JsonPropertyName("code")]
        public int Code { get; }

        [JsonPropertyName("message")]
        public string Message { get; }

        /// <summary>
        /// A collections of last 100 unverified payments.
        /// </summary>
        [JsonPropertyName("authorities")]
        public IEnumerable<AuthorityInfo> Authorities { get; }
    }
}
