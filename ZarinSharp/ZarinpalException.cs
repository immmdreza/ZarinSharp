using System;
using ZarinSharp.Types;

namespace ZarinSharp
{
    /// <summary>
    /// Represents an exception that occurred in Zarinpal.
    /// </summary>
    public class ZarinpalException : Exception
    {
        /// <summary>
        /// Creates a new instance of <see cref="ZarinpalException"/>.
        /// An exception that occurred in Zarinpal.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message.</param>
        /// <returns></returns>
        public ZarinpalException(int code, string? message) : base(message)
        {
            Code = code;
            Description = message;
        }

        /// <summary>
        /// Creates an instance of <see cref="ZarinpalException"/>.
        /// from an instance of <see cref="ZarinpalError"/>.
        /// </summary>
        /// <param name="zarinpalError">The zarinpal error instance</param>
        /// <returns></returns>
        public static ZarinpalException FromZarinpalError(ZarinpalError zarinpalError)
        {
            return new ZarinpalException(
                zarinpalError.Code,
                zarinpalError.Message)
            {
                ZarinpalError = zarinpalError
            };
        }

        /// <summary>
        /// Error code
        /// </summary>
        /// <value></value>
        public int Code { get; set; }

        /// <summary>
        /// The error description
        /// </summary>
        /// <value></value>
        public string? Description { get; set; }

        /// <summary>
        /// Optional. The Zarinpal error instance
        /// </summary>
        public ZarinpalError? ZarinpalError { get; set; }
    }
}
