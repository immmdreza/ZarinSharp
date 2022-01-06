using ZarinSharp.Requests;
using ZarinSharp.Responses;
using ZarinSharp.Types;

namespace ZarinSharp
{
    public interface IZarinClient
    {
        /// <summary>
        /// Your MerchantId or Token from <see href="https://next.zarinpal.com"/>
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Clients configuration.
        /// </summary>
        public ZarinpalConfiguration Configuration { get; }

        /// <summary>
        /// Sends a request.
        /// </summary>
        /// <typeparam name="T">Returned type of <paramref name="request"/> on success.</typeparam>
        /// <param name="request">The method to be requested.</param>
        /// <returns>Returns <typeparamref name="T"/> on success</returns>
        /// <exception cref="ZarinpalException"></exception>
        public Task<ResponseBase<T>> SendRequestAsync<T>(
            RequestBase<ResponseBase<T>> request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request.
        /// </summary>
        /// <typeparam name="T">Returned type of <paramref name="request"/> on success.</typeparam>
        /// <param name="request">The method to be requested.</param>
        /// <exception cref="ZarinpalException"></exception>
        public Task SendRequestAsync(RequestBase request, CancellationToken cancellationToken = default);
    }
}
