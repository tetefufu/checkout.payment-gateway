using System;

namespace checkout.payment_gateway.core
{
    public interface IRepository
    {
        PaymentDetailsDto GetPayment(Guid paymentId);
    }
}