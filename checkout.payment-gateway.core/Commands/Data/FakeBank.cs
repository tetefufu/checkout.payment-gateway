using System.Threading.Tasks;
using checkout.payment_gateway.core.Commands.DTO;
using checkout.payment_gateway.core.Shared;

namespace checkout.payment_gateway.core.Commands.Data
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