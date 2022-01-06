using System.Text.Json.Serialization;
using ZarinSharp.Converters;
using ZarinSharp.Responses;
using ZarinSharp.Types;
using ZarinSharp.Types.Enums;

namespace ZarinSharp.Requests
{
    /// <summary>
    /// Represents a zarinpal payment request.
    /// </summary>
    public class ZarinpalPaymentRequest
        : RequestBase<ResponseBase<ZarinpalPaymentRequestRespond>>
    {
        /// <summary>
        /// Your MerchantId or Token from <see href="https://next.zarinpal.com"/>.
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// The amount of payment.
        /// </summary>
        [JsonPropertyName("amount")]
        public long Amount { get; }

        /// <summary>
        /// Callback url - where user will be redirected after payment.
        /// </summary>
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; }

        /// <summary>
        /// Description of the payment.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; }

        /// <summary>
        /// Optional. Meta data contains mobile and email.
        /// </summary>
        [JsonPropertyName("metadata")]
        public CustomerInfo? Metadata { get; set; }

        /// <summary>
        /// Optional. Information about a wages payment request.
        /// </summary>
        [JsonPropertyName("wages")]
        public IEnumerable<WageInfo>? Wages { get; set; }

        /// <summary>
        /// Indicates the currency of current request amount 
        /// </summary>
        [JsonPropertyName("currency")]
        [JsonConverter(typeof(CurrencyConverter))]
        public Currency? Currency { get; set; }

        /// <summary>
        /// Represents a zarinpal payment request.
        /// </summary>
        /// <param name="merchantId">Your MerchantId or Token from <see cref="https://next.zarinpal.com"/></param>
        /// <param name="amount">The amount of payment</param>
        /// <param name="callbackUrl">Callback url - where user will be redirected after payment.</param>
        /// <param name="description">Description of the payment</param>
        /// <exception cref="ZarinpalException"></exception>
        public ZarinpalPaymentRequest(
            string merchantId,
            long amount,
            string callbackUrl,
            string description) : base("request.json")
        {
            merchantId.ThrowIfNull(nameof(merchantId));
            callbackUrl.ThrowIfNull(nameof(callbackUrl));
            description.ThrowIfNull(nameof(description));
            if (amount < 1000)
                throw new ZarinpalException(501, "Amount can't be less than 1000!");

            MerchantId = merchantId;
            Amount = amount;
            CallbackUrl = callbackUrl;
            Description = description;
        }
    }
}
