using LiteDB;
using System;

namespace checkout.payment_gateway.core
{
    public class Repository : IRepository
    {
        public PaymentDetailsDto GetPayment(Guid paymentId)
        {
            using (var db = new LiteDatabase(@"Data.db"))
            {
                var payments = db.GetCollection<PaymentDetailsDto>("payments");
                payments.EnsureIndex(x => x.PaymentId);

                var payment = payments.FindOne(x => x.PaymentId == paymentId);

                return payment;
            }
        }
    }
}