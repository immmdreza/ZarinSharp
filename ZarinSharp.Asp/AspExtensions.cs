using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZarinSharp.Types;

namespace ZarinSharp.Asp
{
    public static class AspExtensions
    {
        /// <summary>
        /// Adds <see cref="IZarinClient"/> to this <see cref="IServiceCollection"/>
        /// </summary>
        /// <param name="zarinpalConfiguration">Zarinpal configuration.</param>
        public static void AddZarinClient(this IServiceCollection services, ZarinpalConfiguration zarinpalConfiguration)
            => services.AddHttpClient("ZarinSharpClient")
                .AddTypedClient<IZarinClient>(httpClient => new ZarinClient(
                    zarinpalConfiguration, httpClient));

        /// <summary>
        /// Gets <see cref="ZarinpalConfiguration"/> from configs file (appsettings.json)
        /// </summary>
        public static ZarinpalConfiguration GetZarinpalConfiguration(this IConfiguration configuration)
            => configuration.GetSection("ZarinpalConfiguration").Get<ZarinpalConfiguration>();
    }
}
