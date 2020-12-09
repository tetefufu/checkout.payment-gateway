using checkout.payment_gateway.core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace checkout.payment_gateway.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessPaymentController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public ProcessPaymentController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string Post(PaymentDto payment)
        {
            return string.Empty;
        }
    }
}
