using LiteDB;
using LiteDB.Async;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public class ProcessPaymentRepository : IProcessPaymentRepository
    {
        public async Task SaveProcessPaymentRequest(ProcessedPayment processedPayment)
        {
            using (var db = new LiteDatabaseAsync(@"Data.db"))
            {
                var payments = db.GetCollection<ProcessedPayment>("payments");

                await payments.InsertAsync(processedPayment);                

                await payments.EnsureIndexAsync(x => x.PaymentId);
            }
        }
    }
}