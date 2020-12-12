using System;
using System.Threading.Tasks;
using checkout.payment_gateway.core.Queries.DTO;

namespace checkout.payment_gateway.core.Queries
{
    public interface IPastPaymentService
    {
        Task<PastPaymentResponse> GetPayment(Guid paymentId);
    }
}