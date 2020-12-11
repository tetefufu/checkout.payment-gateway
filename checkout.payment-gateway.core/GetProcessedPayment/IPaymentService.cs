using System;

namespace checkout.payment_gateway.core
{
    public interface IPaymentService
    {
        PaymentDetailsDto GetPayment(Guid paymentId);
    }
}