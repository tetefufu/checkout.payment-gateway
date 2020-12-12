using System.Threading.Tasks;
using checkout.payment_gateway.core.Commands.Domain;

namespace checkout.payment_gateway.core.Commands.Data
{
    public interface IProcessPaymentRepository
    {
        Task SaveProcessedPayment(ProcessedPayment processedPayment);
    }
}