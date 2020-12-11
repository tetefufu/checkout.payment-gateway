namespace checkout.payment_gateway.core
{
    public interface IBank
    {
        BankReponse ProcessPayment(PaymentDto paymentDto);
    }
}