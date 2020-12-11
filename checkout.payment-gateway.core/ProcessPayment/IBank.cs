using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public interface IBank
    {
        Task<BankReponse> ProcessPayment(PaymentDto paymentDto);
    }
}