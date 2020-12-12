using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public interface IPastPaymentService
    {
        Task<PastPaymentResponse> GetPayment(Guid paymentId);
    }
}