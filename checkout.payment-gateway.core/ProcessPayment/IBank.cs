using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public interface IBank
    {
        Task<BankResponse> ProcessPayment(PaymentDto paymentDto);
    }
}