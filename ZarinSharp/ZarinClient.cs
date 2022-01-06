using System.Text.Json;
using ZarinSharp.Requests;
using ZarinSharp.Responses;
using ZarinSharp.Types;

namespace ZarinSharp
{
    /// <summary>
    /// Main client to interact with Zarinpal api v4.
    /// </summary>
    public class ZarinClient : IZarinClient
    {
        private readonly ZarinpalConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        public string Token { get; }

        public ZarinpalConfiguration Configuration => _configuration;

        /// <summary>
        /// Create a new instance of <see cref="ZarinClient"/>.
        /// Main client to interact with Zarinpal api v4.
        /// </summary>
        /// <param name="configuration">Your configuration</param>
        /// <param name="httpClient">
        /// Optional <see cref="HttpClient" /> to send requests.
        /// If not provided, a new instance will be created.
        /// </param>
        public ZarinClient(ZarinpalConfiguration configuration, HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();

            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _baseUrl = ZarinpalUrlConfig.GetBaseUrl(_configuration.UseSandbox.NullableBool());

            Token = _configuration.Token;
        }

        private Exception ParseError<T>(JsonDocument jsonDocument)
        {
            var error = jsonDocument.Deserialize<UnsuccessResponseBase<T>>(
                _jsonSerializerOptions);

            if (error is null)
                // If you can't parse the respone error just throw the original exception
                throw new JsonException();

            // get validations
            jsonDocument.RootElement.TryGetProperty("errors", out var errors);
            var validationCollection = new Dictionary<string, List<string?>>();
            if (errors.TryGetProperty("validations", out var validations))
            {
                foreach (var item in validations.EnumerateArray())
                {
                    var property = item.EnumerateObject().First();
                    if (validationCollection.ContainsKey(property.Name))
                    {
                        validationCollection[property.Name].Add(
                            property.Value.GetString());
                    }
                    else
                    {
                        validationCollection.Add(
                            property.Name, new List<string?> { property.Value.GetString() });
                    }
                }
            }

            error.Error.Validations = validationCollection;
            return ZarinpalException.FromZarinpalError(error.Error); // this is not null cuz status code is not success!
        }

        public async Task<ResponseBase<T>> SendRequestAsync<T>(
            RequestBase<ResponseBase<T>> request, CancellationToken cancellationToken = default)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var requestUri = new Uri(new Uri(_baseUrl), relativeUri: request.MethodName);

            var content = request.GetHttpContent(_jsonSerializerOptions);

            if (request is IRequireAuthorization auth)
            {
                content.Headers.Add("authorization", $"Bearer {auth.AccessToken}");
                content.Headers.Add("cache-control", $"no-cache");
            }

            HttpResponseMessage response = await _httpClient.PostAsync(
                requestUri, content, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
                var doc = JsonDocument.Parse(jsonString);

                var dataProperty = doc.RootElement.GetProperty("data");
                if (dataProperty.ValueKind == JsonValueKind.Object)
                {
                    return doc.Deserialize<ResponseBase<T>>(_jsonSerializerOptions) ??
                        throw new ZarinpalException(500, "Unknown error!");
                }
                else
                {
                    // it should be an empty array.
                    throw ParseError<T>(doc);
                }
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
                var doc = JsonDocument.Parse(jsonString);
                throw ParseError<T>(doc);
            }
        }

        public async Task SendRequestAsync(RequestBase request, CancellationToken cancellationToken = default)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var requestUri = new Uri(new Uri(_baseUrl), relativeUri: request.MethodName);

            var content = request.GetHttpContent(_jsonSerializerOptions);

            HttpResponseMessage response = await _httpClient.PostAsync(
                requestUri, content, cancellationToken);

            response.EnsureSuccessStatusCode();
        }
    }
}