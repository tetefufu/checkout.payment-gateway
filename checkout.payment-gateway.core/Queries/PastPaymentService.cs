using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core.Queries
{
    public class PastPaymentService : IPastPaymentService
    {
        private readonly IPastPaymentRepository _paymentQueryRepository;

        public PastPaymentService(IPastPaymentRepository pastPaymentRepository)
        {
            _paymentQueryRepository = pastPaymentRepository;
        }

        public async Task<PastPaymentResponse> GetPayment(Guid paymentId)
        {
            return await _paymentQueryRepository.GetPayment(paymentId);
        }
    }
}
