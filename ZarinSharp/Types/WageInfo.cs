using System.Text.Json.Serialization;

namespace ZarinSharp.Types
{
    /// <summary>
    /// Information about a wage in wages
    /// </summary>
    public class WageInfo
    {
        /// <summary>
        /// Information about a wage in wages
        /// </summary>
        /// <param name="shabaNumber">26 char IBan number starting with IR.</param>
        /// <param name="amount">The amount for this wage</param>
        /// <param name="description">Description of this wage</param>
        public WageInfo(string shabaNumber, long amount, string description)
        {
            ShabaNumber = shabaNumber;
            Amount = amount;
            Description = description;
        }

        /// <summary>
        /// 26 char IBan number starting with IR.
        /// </summary>
        [JsonPropertyName("iban")]
        public string ShabaNumber { get; set; }

        /// <summary>
        /// The amount for this wage
        /// </summary>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Description of this wage
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
