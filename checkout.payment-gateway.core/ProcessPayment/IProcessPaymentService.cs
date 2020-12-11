namespace checkout.payment_gateway.core
{
    public interface IProcessPaymentService
    {
        ProcessPaymentResponse ProcessPayment(PaymentDto paymentDto);
    }
}