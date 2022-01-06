using System.Text.Json.Serialization;

namespace ZarinSharp.Types
{
    public class CustomerInfo
    {
        /// <summary>
        /// Information about a customer
        /// </summary>
        /// <param name="mobile">Customer's mobile number</param>
        /// <param name="email">Customer's email address</param>
        public CustomerInfo(
            string? mobile = default,
            string? email = default,
            string? cardPan = default)
        {
            Mobile = mobile;
            Email = email;
            CardPan = cardPan;
        }

        /// <summary>
        /// Customer's mobile number
        /// </summary>
        [JsonPropertyName("mobile")]
        public string? Mobile { get; }

        /// <summary>
        /// Customer's email address
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; }

        /// <summary>
        /// Customer's card pan - This forces customer to use this card for payment.
        /// </summary>
        [JsonPropertyName("card_pan")]
        public string? CardPan { get; }
    }
}
