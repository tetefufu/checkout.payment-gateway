namespace checkout.payment_gateway.core
{
    public class ProcessPaymentService
    {
        private IBank _bank;

        public ProcessPaymentService(IBank bank)
        {
            _bank = bank;
        }

        public string ProcessPayment(PaymentDto paymentDto)
        {
            return _bank.ProcessPayment(paymentDto);
        }
    }
}
