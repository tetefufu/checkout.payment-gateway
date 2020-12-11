using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public class Bank : IBank
    {
        public async Task<BankResponse> ProcessPayment(PaymentDto paymentDto)
        {
            var response = new BankResponse
            {
                PaymentStatus = BankStatusEnum.Success
            };

            return await Task.FromResult(response); 
        }
    }
}