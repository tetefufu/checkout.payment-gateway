using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public interface IPaymentService
    {
        Task<PaymentDetailsDto> GetPayment(Guid paymentId);
    }
}