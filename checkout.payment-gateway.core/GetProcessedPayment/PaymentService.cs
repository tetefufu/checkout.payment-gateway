using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public class PaymentService : IPaymentService
    {
        private IRepository _bank;

        public PaymentService(IRepository bank)
        {
            _bank = bank;
        }

        public async Task<PaymentDetailsDto> GetPayment(Guid paymentId)
        {
            return await _bank.GetPayment(paymentId);
        }
    }
}
