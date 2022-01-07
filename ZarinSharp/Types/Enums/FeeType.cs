namespace ZarinSharp.Types.Enums
{
    /// <summary>
    /// Represents a payment fee type
    /// </summary>
    public enum FeeType
    {
        /// <summary>
        /// Merchant is gonna pay for payment fee.
        /// </summary>
        Merchant = 0,

        /// <summary>
        /// Payer should pay for payment fee.
        /// </summary>
        Payer = 1,

        /// <summary>
        /// Fee payer is not seralized (Please report!)
        /// </summary>
        UnknownGuy = 2,
    }
}
