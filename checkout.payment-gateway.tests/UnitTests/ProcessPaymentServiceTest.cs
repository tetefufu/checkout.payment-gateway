using checkout.payment_gateway.core.Commands;
using checkout.payment_gateway.core.Commands.Data;
using checkout.payment_gateway.core.Commands.DTO;
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
            Mock<IBank> mockBank = new Mock<IBank>();
            Mock<IProcessPaymentRepository> mockRepo = new Mock<IProcessPaymentRepository>();

            var unit = new ProcessPaymentService(mockBank.Object, mockRepo.Object);

            unit.ProcessPayment(IntegrationTests.IntegrationTests.ValidPaymentRequest());

            mockBank.Verify(m => m.ProcessPayment(It.IsAny<ProcessPaymentRequest>()), Times.Once);
        }

        [TestMethod]
        public void WhenPaymentProcessedThenReturnPaymentId()
        {
            Mock<IBank> mockBank = new Mock<IBank>();
            Mock<IProcessPaymentRepository> mockRepo = new Mock<IProcessPaymentRepository>();

            var unit = new ProcessPaymentService(mockBank.Object, mockRepo.Object);

            var paymentIdReturned = unit.ProcessPayment(IntegrationTests.IntegrationTests.ValidPaymentRequest());

            Assert.IsNotNull(paymentIdReturned);
        }
    }
}
