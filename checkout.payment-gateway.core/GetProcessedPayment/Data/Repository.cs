using LiteDB;
using LiteDB.Async;
using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public class Repository : IRepository
    {
        public async Task<PaymentDetailsDto> GetPayment(Guid paymentId)
        {
            using (var db = new LiteDatabaseAsync(@"Data.db"))
            {
                var payments = db.GetCollection<PaymentDetailsDto>("payments");
                
                await payments.EnsureIndexAsync(x => x.PaymentId);

                var payment = await payments.FindOneAsync(x => x.PaymentId == paymentId);

                return payment;
            }
        }
    }
}