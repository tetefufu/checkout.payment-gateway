using System;

namespace checkout.payment_gateway.core
{
    public interface IProcessPaymentRepository
    {
        void SaveProcessPaymentRequest(ProcessedPayment processedPayment);
    }
}