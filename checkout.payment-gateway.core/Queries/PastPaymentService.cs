using System;
using System.Threading.Tasks;
using checkout.payment_gateway.core.Queries.Data;
using checkout.payment_gateway.core.Queries.DTO;

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
