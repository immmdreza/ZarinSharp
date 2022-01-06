namespace ZarinSharp.Requests
{
    public interface IRequireAuthorization
    {
        /// <summary>
        /// Access token required to invoke this request.
        /// </summary>
        public string AccessToken { get; }
    }
}
