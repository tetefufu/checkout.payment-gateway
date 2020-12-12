namespace checkout.payment_gateway.core.Commands.DTO
{
    public class CreditCard
    {
        public string Name { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
        public int ExpiryYear { get; set; }
        public int ExpiryMonth { get; set; }
    }
}