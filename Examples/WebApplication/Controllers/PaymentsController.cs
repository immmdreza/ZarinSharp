using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ZarinSharp;
using ZarinSharp.Responses;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;

        // Get ZarinClient from services collection via DI.
        private readonly IZarinClient _zarinClient;

        public PaymentController(
            ILogger<PaymentController> logger,
            IZarinClient zarinClient)
        {
            _logger = logger;
            _zarinClient = zarinClient;
        }

        #region Request Payment
        [HttpGet]
        public async Task<ZarinpalPaymentRequestRespond> GetAsync()
        {
            _logger.LogInformation("Requested a payment");
            
            // Request a payment.
            return await _zarinClient.PaymentRequestAsync(20000, "This is my payment!");
        }
        #endregion

        #region Verify Payment
        [HttpGet("verify")]
        public async Task<bool> VerifyAsync(string authority, string status)
        {
            _logger.LogInformation("Verifing a payment");

            // Verify a payment.
            try
            {
                var verify = await _zarinClient.VerifyPaymentAsync(20000, authority);
                _logger.LogInformation($"Payment {verify.RefId} verified!");
                return true;
            }
            catch(ZarinpalException e)
            {
                _logger.LogWarning($"Not verified {authority}, {e.Message}");
                return false;
            }
        }
        #endregion
    }
}
