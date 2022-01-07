using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ZarinSharp.Requests;
using ZarinSharp.Responses;
using ZarinSharp.Types;
using ZarinSharp.Types.Enums;

namespace ZarinSharp
{
    /// <summary>
    /// Provides a collection of usefull extension methods
    /// </summary>
    public static class ZarinExtensions
    {
        /// <summary>
        /// Indicates a nullable value is not null here.
        /// </summary>
        /// <param name="nullalbeThing">Nullable value</param>
        /// <param name="paramName">The name of parameter which can be null.</param>
        /// <typeparam name="T">Type of object</typeparam>
        internal static void ThrowIfNull<T>(this T? nullalbeThing, string paramName)
            where T : class
        {
            if (nullalbeThing == null)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Converts a nullable Boolean to non nullable Boolean
        /// </summary>
        /// <param name="value">Nullable boolean value</param>
        internal static bool NullableBool(this bool? value)
            => value != null && value.Value;

        /// <summary>
        /// Requests a payment.
        /// </summary>
        /// <param name="amount">The amount of payment in Toman</param>
        /// <param name="description">Description of payment</param>
        /// <param name="customerInfo">Customer's info such as email mobile, ...</param>
        /// <param name="wageInfos">A collection of wages</param>
        /// <param name="callback_url">Overrides callback url specified in configs</param>
        /// <param name="currency">IRR or IRT as currency</param>
        /// <exception cref="ZarinpalException"></exception>
        public static async Task<ZarinpalPaymentRequestRespond> PaymentRequestAsync(
            this IZarinClient client,
            long amount,
            string description,
            CustomerInfo? customerInfo = null,
            IEnumerable<WageInfo>? wageInfos = null,
            string? callback_url = default,
            Currency? currency = default,
            CancellationToken cancellationToken = default)
        {
            client.ThrowIfNull(nameof(client));

            var response = await client.SendRequestAsync(
                new ZarinpalPaymentRequest(
                    client.Token,
                    amount,
                    callback_url?? client.Configuration.CallbackUrl,
                    description)
                {
                    Metadata = customerInfo,
                    Wages = wageInfos,
                    Currency = currency
                },
                cancellationToken);

            if (response.Data is null)
                throw new ZarinpalException(-1000, "Unknown error!");

            response.Data.EnsureSuccess();

            return response.Data;
        }

        /// <summary>
        /// Verifies a payment.
        /// </summary>
        /// <param name="amount">The amount of payment in Toman</param>
        /// <param name="authority">The authority of the payment</param>
        /// <exception cref="ZarinpalException"></exception>
        public static async Task<ZarinpalVerifyResponse> VerifyPaymentAsync(
            this IZarinClient client,
            long amount,
            string authority,
            CancellationToken cancellationToken = default)
        {
            client.ThrowIfNull(nameof(client));

            var response = await client.SendRequestAsync(
                new ZarinpalVerifyRequest(
                    client.Token,
                    amount,
                    authority),
                cancellationToken);

            if (response.Data is null)
                throw new ZarinpalException(-1000, "Unknown error!");

            response.Data.EnsureVerifiedOrDuplicated();

            return response.Data;
        }

        /// <summary>
        /// Request to get last 100 unverified payments.
        /// </summary>
        /// <exception cref="ZarinpalException"></exception>
        public static async Task<ZarinpalUnVerifiedResponse> GetUnVerifiedAsync(
            this IZarinClient client)
        {
            client.ThrowIfNull(nameof(client));

            var response = await client.SendRequestAsync(
                new ZarinpalUnVerifiedRequest(client.Token));

            if (response.Data is null)
                throw new ZarinpalException(-1000, "Unknown error!");

            response.Data.EnsureSuccess();

            return response.Data;
        }

        /// <summary>
        /// Request to refund a payment.
        /// </summary>
        /// <param name="authority">The authority of the payment.</param>
        /// <param name="accessToken">Your access token from <see href="https://next.zarinpal.com"/></param>
        /// <exception cref="ZarinpalException"></exception>
        public static async Task<ZarinpalRefundResponse> RefundAsync(
            this IZarinClient client,
            string authority,
            string accessToken)
        {
            client.ThrowIfNull(nameof(client));

            var response = await client.SendRequestAsync(
                new ZarinpalRefundRequest(
                    client.Token,
                    authority,
                    accessToken));

            if (response.Data is null)
                throw new ZarinpalException(-1000, "Unknown error!");

            response.Data.EnsureSuccess();

            return response.Data;
        }
    }
}
