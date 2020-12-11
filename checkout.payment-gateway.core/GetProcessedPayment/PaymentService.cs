using System;

namespace checkout.payment_gateway.core
{
    public class PaymentService : IPaymentService
    {
        private IRepository _bank;

        public PaymentService(IRepository bank)
        {
            _bank = bank;
        }

        public PaymentDetailsDto GetPayment(Guid paymentId)
        {
            return _bank.GetPayment(paymentId);
        }
    }
}
