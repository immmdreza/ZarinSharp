using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarinSharp.Requests
{
    /// <summary>
    /// Basic request.
    /// </summary>
    /// <typeparam name="T">Return type of request.</typeparam>
    public abstract class RequestBase
    {
        protected RequestBase(string methodName)
        {
            MethodName = methodName;
        }

        [JsonIgnore]
        public string MethodName { get; }

        public HttpContent GetHttpContent(JsonSerializerOptions options)
        {
            var data = JsonSerializer.Serialize(this, GetType(), options);
            return new StringContent(
                data,
                encoding: Encoding.UTF8,
                "application/json");
        }
    }

    public abstract class RequestBase<T> : RequestBase
    {
        protected RequestBase(string methodName) : base(methodName) { }
    }
}
