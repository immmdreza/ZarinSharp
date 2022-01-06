namespace ZarinSharp
{
    internal static class ZarinpalUrlConfig
    {
        // Zarinpal api v4
        private const string _requestUrl = "https://api.zarinpal.com/pg/v4/payment/";
        private const string _startPayUrl = "https://www.zarinpal.com/pg/StartPay/";

        private const string _sandboxRequestUrl = "https://sandbox.zarinpal.com/pg/v4/payment/";
        private const string _sandboxStartPayUrl = "https://sandbox.zarinpal.com/pg/StartPay/";

        public static string GetBaseUrl(bool? useSandbox)
            => useSandbox.NullableBool() ? _sandboxRequestUrl : _requestUrl;

        public static string GetPaymenGatewayUrl(string authority, bool? useSandbox)
            => (useSandbox.NullableBool() ? _sandboxStartPayUrl : _startPayUrl) + authority;
    }
}
