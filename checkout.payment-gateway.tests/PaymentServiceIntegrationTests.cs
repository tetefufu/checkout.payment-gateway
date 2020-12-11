using checkout.payment_gateway.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using System.Threading.Tasks;

namespace checkout.payment_gateway.tests
{
    [TestClass]
    public class PaymentServiceIntegrationTests
    {
        [TestMethod]
        public async Task GivenPaymentProcessed_WhenProcessAndGetPayment_ThenPaymentDetailsReturned()
        {
            Mock<IBank> mockBank = new Mock<IBank>();
            var processPaymentService = new ProcessPaymentService(mockBank.Object, new ProcessPaymentRepository());
            var paymentService = new PaymentService(new Repository());

            var processPaymentResponse = await processPaymentService.ProcessPayment(IntegrationTests.ValidPaymentRequest());
            var payment = paymentService.GetPayment(processPaymentResponse.PaymentId);

            payment.PaymentId.ShouldBe(processPaymentResponse.PaymentId);
            payment.MaskedCreditCardNumber.ShouldBe("4321");
        }
    }
}