namespace checkout.payment_gateway.core
{
    public interface IBank
    {
        string ProcessPayment(PaymentDto paymentDto);
    }
}