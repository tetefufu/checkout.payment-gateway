using System;
using System.Threading.Tasks;
using checkout.payment_gateway.core.Queries.DTO;

namespace checkout.payment_gateway.core.Queries.Data
{
    public interface IPastPaymentRepository
    {
        Task<PastPaymentResponse> GetPayment(Guid paymentId);
    }
}