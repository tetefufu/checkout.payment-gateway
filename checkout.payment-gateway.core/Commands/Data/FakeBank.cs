using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public class FakeBank : IBank
    {
        public async Task<BankResponse> ProcessPayment(ProcessPaymentRequest paymentDto)
        {
            var response = new BankResponse
            {
                PaymentStatus = BankStatusEnum.Success
            };

            return await Task.FromResult(response); 
        }
    }
}