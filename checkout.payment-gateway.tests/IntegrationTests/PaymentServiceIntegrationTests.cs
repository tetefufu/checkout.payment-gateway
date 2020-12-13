using System.Threading.Tasks;
using checkout.payment_gateway.core.Commands;
using checkout.payment_gateway.core.Commands.Data;
using checkout.payment_gateway.core.Queries;
using checkout.payment_gateway.core.Queries.Data;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace checkout.payment_gateway.tests.IntegrationTests
{
    [TestClass]
    public class PaymentServiceIntegrationTests
    {
        [TestMethod]
        public async Task GivenPaymentProcessed_WhenProcessAndGetPayment_ThenPaymentDetailsReturned()
        {
            Mock<IBank> mockBank = new Mock<IBank>();
            var mockLogger = new Mock<ILogger<ProcessPaymentService>>();

            var processPaymentService = new ProcessPaymentService(mockLogger.Object, mockBank.Object, new ProcessPaymentRepository(), new ProcessPaymentRequestValidator());
            var paymentService = new PastPaymentService(new PastPaymentRepository());

            var processPaymentRequest = ProcessPaymentServiceIntegrationTests.ValidPaymentRequest();
            var processPaymentResponse = await processPaymentService.ProcessPayment(processPaymentRequest);
            var payment = await paymentService.GetPayment(processPaymentResponse.PaymentId);

            payment.PaymentId.ShouldBe(processPaymentResponse.PaymentId);
            payment.MaskedCreditCardNumber.ShouldBe("4321");
            payment.Amount.ShouldBe(processPaymentRequest.Amount);
            payment.Currency.ShouldBe(processPaymentRequest.Currency);
        }
    }
}