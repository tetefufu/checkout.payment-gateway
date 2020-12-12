namespace checkout.payment_gateway.core
{
    public class BankResponse
    {
        public BankStatusEnum PaymentStatus { get; set; }
        public string Message { get; set; }
    }
}