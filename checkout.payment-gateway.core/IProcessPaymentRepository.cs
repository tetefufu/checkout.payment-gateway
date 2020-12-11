using System;

namespace checkout.payment_gateway.core
{
    public interface IProcessPaymentRepository
    {
        Guid SaveProcessPaymentRequest(PaymentDto paymentDto, BankReponse bankReponse);
    }
}