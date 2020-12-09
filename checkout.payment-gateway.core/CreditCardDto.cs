namespace checkout.payment_gateway.core
{
    public class CreditCardDto
    {
        public string Name { get; set; }
        public long CardNumber { get; set; }
        public int ExpiryYear { get; set; }
        public int ExpiryMonth { get; set; }
    }
}