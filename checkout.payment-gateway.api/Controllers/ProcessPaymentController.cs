using checkout.payment_gateway.core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace checkout.payment_gateway.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessPaymentController : ControllerBase
    {
        private readonly ILogger<ProcessPaymentController> _logger;
        private readonly IProcessPaymentService _processPaymentService;

        public ProcessPaymentController(ILogger<ProcessPaymentController> logger, IProcessPaymentService processPaymentService)
        {
            _logger = logger;
            _processPaymentService = processPaymentService;
        }

        [HttpPost]
        public async Task<ProcessPaymentResponse> Post(PaymentDto payment)
        {
            return await _processPaymentService.ProcessPayment(payment);
        }
    }
}
