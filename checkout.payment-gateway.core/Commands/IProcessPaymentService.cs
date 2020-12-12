using System.Threading.Tasks;
using checkout.payment_gateway.core.Commands.DTO;

namespace checkout.payment_gateway.core.Commands
{
    public interface IProcessPaymentService
    {
        Task<ProcessPaymentResponse> ProcessPayment(ProcessPaymentRequest processPaymentRequest);
    }
}