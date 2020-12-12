using System;

namespace checkout.payment_gateway.core.Commands.DTO
{
    public class ProcessPaymentResponse
    {
        public Guid PaymentId { get; set; }
    }
}