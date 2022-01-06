// See https://aka.ms/new-console-template for more information
using ZarinSharp;
using ZarinSharp.Types;

Console.WriteLine("Hello, World!");

// Putout your configurations: MerchantId or Token from https://next.zarinpal.com.
//                             Default callback url 
var token = "YOUR_TOKEN_HERE";
var defaultCallbackUrl = "www.example.com"; // This can be overrided later.
var configs = new ZarinpalConfiguration(token, defaultCallbackUrl);

// Create main client
var zarinClient = new ZarinClient(configs);

// Request a payment
var payRequest = await zarinClient.PaymentRequestAsync(20000, "I will pay for you");

// Get a link to pay getway
var getwayLink = payRequest.GetStartPaymentUrl();

// User is gonna pay meanwhile
// ...

// verify that payment.
var verifyResult = await zarinClient.VerifyPaymentAsync(20000, payRequest.Authority);

Console.WriteLine($"Payment verified from {verifyResult.CardPan}");
