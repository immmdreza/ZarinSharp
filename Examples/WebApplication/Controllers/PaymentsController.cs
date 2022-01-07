using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ZarinSharp;
using ZarinSharp.Responses;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IZarinClient _zarinClient;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IZarinClient zarinClient)
        {
            _logger = logger;
            _zarinClient = zarinClient;
        }

        [HttpGet]
        public async Task<ZarinpalPaymentRequestRespond> GetAsync()
        {
            return await _zarinClient.PaymentRequestAsync(20000, "This is my payment!");
        }
    }
}
