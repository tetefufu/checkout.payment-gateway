using System;
using System.Threading.Tasks;

namespace checkout.payment_gateway.core
{
    public class ProcessPaymentService : IProcessPaymentService
    {
        private IBank _bank;
        private readonly IProcessPaymentRepository _processPaymentRepository;

        public ProcessPaymentService(IBank bank, IProcessPaymentRepository processPaymentRepository)
        {
            _bank = bank;
            _processPaymentRepository = processPaymentRepository;
        }

        public async Task<ProcessPaymentResponse> ProcessPayment(ProcessPaymentRequest paymentDto)
        {
            var bankResponse = await GetBankResponse(paymentDto);

            var processedPayment = new ProcessedPayment(paymentDto, bankResponse);

            await _processPaymentRepository.SaveProcessedPayment(processedPayment);

            return new ProcessPaymentResponse
            {
                PaymentId = processedPayment.PaymentId
            };
        }

        private async Task<BankResponse> GetBankResponse(ProcessPaymentRequest payment)
        {
            try
            {
                return await _bank.ProcessPayment(payment);
            }
            catch (Exception e)
            {
                // log error
                return null;
            }
        }
    }
}
