using LiteDB;
using LiteDB.Async;
using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public class PastPaymentReponse : IPastPaymentRepository
    {
        public async Task<PastPaymentResponse> GetPayment(Guid paymentId)
        {
            using (var db = new LiteDatabaseAsync(@"Data.db"))
            {
                var payments = db.GetCollection<PastPaymentResponse>("payments");
                
                await payments.EnsureIndexAsync(x => x.PaymentId);

                var payment = await payments.FindOneAsync(x => x.PaymentId == paymentId);

                return payment;
            }
        }
    }
}