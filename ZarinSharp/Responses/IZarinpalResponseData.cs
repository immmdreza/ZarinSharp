namespace ZarinSharp.Responses
{
    /// <summary>
    /// Represents a zarinpal response data required properties
    /// </summary>
    public interface IZarinpalResponseData
    {
        /// <summary>
        /// Response code in number
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// The message.
        /// </summary>
        public string Message { get; }
    }
}
