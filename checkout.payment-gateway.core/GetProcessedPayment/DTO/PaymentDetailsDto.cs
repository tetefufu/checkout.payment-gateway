using System;

namespace checkout.payment_gateway.core
{
    public class PaymentDetailsDto
    {
        public Guid PaymentId { get; set; }
        public string MaskedCreditCardNumber { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public BankResponse BankResponse { get; internal set; }
    }
}