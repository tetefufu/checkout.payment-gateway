using System.Threading.Tasks;
using checkout.payment_gateway.core.Commands.DTO;

namespace checkout.payment_gateway.core.Commands.Data
{
    public interface IBank
    {
        Task<BankResponse> ProcessPayment(ProcessPaymentRequest paymentDto);
    }
}