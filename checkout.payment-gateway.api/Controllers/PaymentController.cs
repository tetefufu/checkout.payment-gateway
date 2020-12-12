using checkout.payment_gateway.core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace checkout.payment_gateway.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentController(ILogger<WeatherForecastController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpGet]
        public PaymentDetailsDto Get(Guid paymentId)
        {
            return _paymentService.GetPayment(paymentId);
        }
    }
}
