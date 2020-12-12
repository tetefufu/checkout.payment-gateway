using checkout.payment_gateway.core.Shared;

namespace checkout.payment_gateway.core.Commands.DTO
{
    public class BankResponse
    {
        public BankStatusEnum PaymentStatus { get; set; }
        public string Message { get; set; }
    }
}