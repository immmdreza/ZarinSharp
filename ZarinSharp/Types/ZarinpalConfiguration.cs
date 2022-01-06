namespace ZarinSharp.Types;

public class ZarinpalConfiguration
{
    public ZarinpalConfiguration(
        string token,
        string callbackUrl,
        bool? useSandbox = default)
    {
        token.ThrowIfNull(nameof(token));
        callbackUrl.ThrowIfNull(nameof(callbackUrl));

        Token = token;
        CallbackUrl = callbackUrl;
        UseSandbox = useSandbox;
    }

    /// <summary>
    /// Your MerchantId or Token from <see href="https://next.zarinpal.com"/>
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// The callback url - User will get redireted here.
    /// </summary>
    public string CallbackUrl { get; set; }

    /// <summary>
    /// Indicates if requests should be sent to sandbox api - Test perpouses.
    /// </summary>
    public bool? UseSandbox { get; set; }
}
