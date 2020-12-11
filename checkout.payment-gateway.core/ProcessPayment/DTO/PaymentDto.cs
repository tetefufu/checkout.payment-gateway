using System;

namespace checkout.payment_gateway.core
{
    public class PaymentDto
    {
        public CreditCardDto CreditCard { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
