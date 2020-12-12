using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core.Queries.Data
{
    public interface IPastPaymentRepository
    {
        Task<DTO.PastPaymentResponse> GetPayment(Guid paymentId);
    }
}