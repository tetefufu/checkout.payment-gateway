using checkout.payment_gateway.core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPastPaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPastPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<PastPaymentResponse> Get(Guid paymentId)
        {
            return await _paymentService.GetPayment(paymentId);
        }
    }
}
