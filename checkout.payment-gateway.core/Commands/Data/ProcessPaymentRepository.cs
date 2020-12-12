using System.Threading.Tasks;
using checkout.payment_gateway.core.Commands.Domain;
using LiteDB.Async;

namespace checkout.payment_gateway.core.Commands.Data
{
    public class ProcessPaymentRepository : IProcessPaymentRepository
    {
        public async Task SaveProcessedPayment(ProcessedPayment processedPayment)
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