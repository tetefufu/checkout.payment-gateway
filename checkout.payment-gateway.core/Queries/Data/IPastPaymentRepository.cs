using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public interface IPastPaymentRepository
    {
        Task<PastPaymentResponse> GetPayment(Guid paymentId);
    }
}