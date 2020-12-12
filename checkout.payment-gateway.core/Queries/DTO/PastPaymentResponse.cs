using System;
using checkout.payment_gateway.core.Commands.DTO;

namespace checkout.payment_gateway.core.Queries.DTO
{
    public class PastPaymentResponse
    {
        public Guid PaymentId { get; set; }
        public string MaskedCreditCardNumber { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public BankResponse BankResponse { get; internal set; }
    }
}