using System;

namespace checkout.payment_gateway.core
{
    public class ProcessPaymentRequest
    {
        public CreditCard CreditCard { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
