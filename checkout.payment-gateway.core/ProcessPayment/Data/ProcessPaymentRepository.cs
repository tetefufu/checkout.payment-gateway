using LiteDB;

namespace checkout.payment_gateway.core
{
    public class ProcessPaymentRepository : IProcessPaymentRepository
    {
        public void SaveProcessPaymentRequest(ProcessedPayment processedPayment)
        {
            using (var db = new LiteDatabase(@"Data.db"))
            {
                var payments = db.GetCollection<ProcessedPayment>("payments");

                payments.Insert(processedPayment);                

                payments.EnsureIndex(x => x.PaymentId);
            }
        }
    }
}