# ZarinpalSharp
[.NET Standard 2.1](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support) client for zarinpal api v4

Install from [Nuget](https://www.nuget.org/packages/ZarinpalSharp/) (⚠️ Not fully tested! but i did some on common methods)

## Why?
For better understanding of what is this and why you should use this, please read [Zarinpal docs](https://docs.zarinpal.com/paymentGateway/)

Using this package you can simply send a payment request with specified amount of money. customer will pay and you will verify!

## How to?
See [ConsoleApplication](Examples/ConsoleApplication) for a quick example

You need `MerchantId` from [Zarinpal Panel](https://next.zarinpal.com/)

### Basic Usage
1- Create a client

```cs
// Putout your configurations: MerchantId or Token from https://next.zarinpal.com.
//                             Default callback url 
var token = "YOUR_TOKEN_HERE";
var defaultCallbackUrl = "www.example.com"; // This can be overrided later.
var configs = new ZarinpalConfiguration(token, defaultCallbackUrl);

// Create main client
var zarinClient = new ZarinClient(configs);
```

2- Send Requests like `PaymentRequestAsync`
```cs
// Request a payment
var payRequest = await zarinClient.PaymentRequestAsync(20000, "I will pay for you");

// Get a link to pay gateway
var gatewayLink = payRequest.GetStartPaymentUrl()
```

### Supported methods
  - [Payment request](https://docs.zarinpal.com/paymentGateway/guide/#%D8%A7%D8%B1%D8%B3%D8%A7%D9%84-%D8%A7%D8%B7%D9%84%D8%A7%D8%B9%D8%A7%D8%AA)
  - [Verify peyment](https://docs.zarinpal.com/paymentGateway/guide/#%D8%A8%D8%A7%D8%B2%DA%AF%D8%B4%D8%AA-%D8%A8%D9%87-%D8%B3%D8%A7%DB%8C%D8%AA-%D9%BE%D8%B0%DB%8C%D8%B1%D9%86%D8%AF%D9%87)
  - [Get UnVerified](https://docs.zarinpal.com/paymentGateway/other/#unverified)
  - [Refund](https://docs.zarinpal.com/paymentGateway/other/#refund)

Almost everything is supported: `CardPan`, `Wages`, `Currency` and ...

_Consider reading [Wiki](https://github.com/immmdreza/ZarinpalSharp/wiki) (even if it's empty)._
