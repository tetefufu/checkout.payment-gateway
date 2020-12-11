using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public interface IProcessPaymentRepository
    {
        Task SaveProcessPaymentRequest(ProcessedPayment processedPayment);
    }
}