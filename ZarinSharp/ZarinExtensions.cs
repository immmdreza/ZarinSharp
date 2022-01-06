using ZarinSharp.Requests;
using ZarinSharp.Responses;
using ZarinSharp.Types;

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
        /// <exception cref="ZarinpalException"></exception>
        public static async Task<ZarinpalPaymentRequestRespond> PaymentRequestAsync(
            this ZarinClient client,
            long amount,
            string description,
            CustomerInfo? customerInfo = null,
            CancellationToken cancellationToken = default)
        {
            client.ThrowIfNull(nameof(client));

            var response = await client.SendRequestAsync(
                new ZarinpalPaymentRequest(
                    client.Token,
                    amount,
                    client.Configuration.CallbackUrl,
                    description)
                {
                    Metadata = customerInfo
                },
                cancellationToken);

            if (response.Data is null)
                throw new ZarinpalException(500, "Unknown error!");

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
            this ZarinClient client,
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
                throw new ZarinpalException(500, "Unknown error!");

            response.Data.EnsureVerifiedOrDuplicated();

            return response.Data;
        }
    }
}
