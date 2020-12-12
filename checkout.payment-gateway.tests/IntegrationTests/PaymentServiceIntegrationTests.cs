using System.Threading.Tasks;
using checkout.payment_gateway.core.Commands;
using checkout.payment_gateway.core.Commands.Data;
using checkout.payment_gateway.core.Queries;
using checkout.payment_gateway.core.Queries.Data;
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
            var processPaymentService = new ProcessPaymentService(mockBank.Object, new ProcessPaymentRepository());
            var paymentService = new PastPaymentService(new PastPaymentRepository());

            var processPaymentResponse = await processPaymentService.ProcessPayment(IntegrationTests.ValidPaymentRequest());
            var payment = await paymentService.GetPayment(processPaymentResponse.PaymentId);

            payment.PaymentId.ShouldBe(processPaymentResponse.PaymentId);
            payment.MaskedCreditCardNumber.ShouldBe("4321");
        }
    }
}