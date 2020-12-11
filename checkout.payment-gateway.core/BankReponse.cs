namespace checkout.payment_gateway.core
{
    public class BankReponse
    {
        public BankStatusEnum PaymentStatus { get; set; }
        public string Message { get; set; }
    }
}