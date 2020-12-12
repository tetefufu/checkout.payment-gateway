using System;
using System.Threading.Tasks;
using checkout.payment_gateway.core.Commands.Data;
using checkout.payment_gateway.core.Commands.Domain;
using checkout.payment_gateway.core.Commands.DTO;
using Microsoft.Extensions.Logging;

namespace checkout.payment_gateway.core.Commands
{
    public class ProcessPaymentService : IProcessPaymentService
    {
        private readonly IBank _bank;
        private readonly IProcessPaymentRepository _processPaymentRepository;
        private readonly ICreditCardValidator _creditCardValidator;
        private readonly ILogger _logger;

        public ProcessPaymentService(
            ILogger<ProcessPaymentService> logger, 
            IBank bank, 
            IProcessPaymentRepository processPaymentRepository,
            ICreditCardValidator creditCardValidator)
        {
            _logger = logger;
            _bank = bank;
            _processPaymentRepository = processPaymentRepository;
            _creditCardValidator = creditCardValidator;
        }

        public async Task<ProcessPaymentResponse> ProcessPayment(ProcessPaymentRequest paymentDto)
        {
            _creditCardValidator.Validate(paymentDto.CreditCard);

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
                _logger.LogError(e, $"Bank Service Error: {e.Message}");

                return null;
            }
        }
    }
}
