## Steps to build
Here are the minimum changes you need to made.

1. ### Add configurations
Open file  `appsettings.json` and put your configs there.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ZarinpalConfiguration": {
    "Token": "1344b5d4-0048-11e8-94db-005056a205be",
    "CallbackUrl": "http://yoursite.com/verify"
  }
}
```
> I mean `ZarinpalConfiguration` part.

2. ### Add `ZarinClient` to `IServiceCollection`

```cs
services.AddZarinClient(Configuration.GetZarinpalConfiguration());
```

3. ### Use it
Use `IZarinClient` in your controller to request payments and verify them.

See [PaymentsController](https://github.com/immmdreza/ZarinpalSharp/blob/master/Examples/WebApplication/Controllers/PaymentsController.cs)
