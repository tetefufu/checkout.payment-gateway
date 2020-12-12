using checkout.payment_gateway.core.Commands;
using checkout.payment_gateway.core.Commands.Data;
using checkout.payment_gateway.core.Commands.DTO;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace checkout.payment_gateway.tests.UnitTests
{
    [TestClass]
    public class ProcessPaymentServiceTest
    {
        [TestMethod]
        public void WhenPaymentProcessedThenBankApiIsCalled()
        {
            var mockBank = new Mock<IBank>();
            var mockRepo = new Mock<IProcessPaymentRepository>();
            var mockLogger = new Mock<ILogger<ProcessPaymentService>>();

            var unit = new ProcessPaymentService(mockLogger.Object, mockBank.Object, mockRepo.Object);

            unit.ProcessPayment(IntegrationTests.IntegrationTests.ValidPaymentRequest());

            mockBank.Verify(m => m.ProcessPayment(It.IsAny<ProcessPaymentRequest>()), Times.Once);
        }

        [TestMethod]
        public void WhenPaymentProcessedThenReturnPaymentId()
        {
            var mockBank = new Mock<IBank>();
            var mockRepo = new Mock<IProcessPaymentRepository>();
            var mockLogger = new Mock<ILogger<ProcessPaymentService>>();

            var unit = new ProcessPaymentService(mockLogger.Object, mockBank.Object, mockRepo.Object);

            var paymentIdReturned = unit.ProcessPayment(IntegrationTests.IntegrationTests.ValidPaymentRequest());

            Assert.IsNotNull(paymentIdReturned);
        }
    }
}
