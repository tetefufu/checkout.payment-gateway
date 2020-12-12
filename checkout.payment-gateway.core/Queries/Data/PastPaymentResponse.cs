using System;
using System.Threading.Tasks;
using LiteDB.Async;

namespace checkout.payment_gateway.core.Queries.Data
{
    public class PastPaymentResponse : IPastPaymentRepository
    {
        public async Task<DTO.PastPaymentResponse> GetPayment(Guid paymentId)
        {
            using (var db = new LiteDatabaseAsync(@"Data.db"))
            {
                var payments = db.GetCollection<DTO.PastPaymentResponse>("payments");
                
                await payments.EnsureIndexAsync(x => x.PaymentId);

                var payment = await payments.FindOneAsync(x => x.PaymentId == paymentId);

                return payment;
            }
        }
    }
}