using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public interface IProcessPaymentService
    {
        Task<ProcessPaymentResponse> ProcessPayment(PaymentDto paymentDto);
    }
}