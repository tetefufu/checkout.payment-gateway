﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using checkout.payment_gateway.core.Commands;
using checkout.payment_gateway.core.Commands.DTO;
using checkout.payment_gateway.core.Queries;
using checkout.payment_gateway.core.Queries.DTO;

namespace checkout.payment_gateway.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPastPaymentService _paymentService;
        private readonly IProcessPaymentService _processPaymentService;

        public PaymentsController(
            ILogger<PaymentsController> logger,
            IPastPaymentService pastPaymentService,
            IProcessPaymentService processPaymentService)
        {
            _logger = logger;
            _paymentService = pastPaymentService;
            _processPaymentService = processPaymentService;
        }

        [HttpGet]
        [Route("{paymentId}")]
        public async Task<PastPaymentResponse> Get(Guid paymentId)
        {
            return await _paymentService.GetPayment(paymentId);
        }

        [HttpPost]
        public async Task<ProcessPaymentResponse> Post(ProcessPaymentRequest payment)
        {
            return await _processPaymentService.ProcessPayment(payment);
        }
    }
}