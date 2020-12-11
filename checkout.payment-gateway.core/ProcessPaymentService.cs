using System;

namespace checkout.payment_gateway.core
{
    public class ProcessPaymentService
    {
        private IBank _bank;
        private readonly IProcessPaymentRepository _processPaymentRepository;

        public ProcessPaymentService(IBank bank, IProcessPaymentRepository processPaymentRepository)
        {
            _bank = bank;
            _processPaymentRepository = processPaymentRepository;
        }

        public Guid ProcessPayment(PaymentDto paymentDto)
        {
            var bankResponse = GetBankResponse(paymentDto);

            var processedPayment = new ProcessedPayment(paymentDto, bankResponse);

            _processPaymentRepository.SaveProcessPaymentRequest(processedPayment);

            return processedPayment.PaymentId;
        }

        private BankReponse GetBankResponse(PaymentDto payment)
        {
            try
            {
                return _bank.ProcessPayment(payment);
            }
            catch (Exception e)
            {
                // log error
                return null;
            }
        }
    }
}
