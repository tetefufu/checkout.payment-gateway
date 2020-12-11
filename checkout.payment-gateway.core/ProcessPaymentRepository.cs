using LiteDB;
using System;

namespace checkout.payment_gateway.core
{
    public class ProcessPaymentRepository : IProcessPaymentRepository
    {
        public Guid SaveProcessPaymentRequest(PaymentDto paymentDto, BankReponse bankReponse)
        {
            var paymentId = Guid.NewGuid();

            using (var db = new LiteDatabase(@"Data.db"))
            {
                var payments = db.GetCollection<PaymentDetailsDto>("payments");

                var payment = new PaymentDetailsDto
                {
                    PaymentId = paymentId,
                    BankResponse = bankReponse,
                    Currency = paymentDto.Currency,
                    Amount = paymentDto.Amount
                };

                payments.Insert(payment);                
                payments.EnsureIndex(x => x.PaymentId);
            }

            return paymentId;
        }
    }
}