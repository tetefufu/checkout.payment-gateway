using checkout.payment_gateway.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace checkout.payment_gateway.tests
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

            unit.ProcessPayment(IntegrationTests.ValidPaymentRequest());

            mockBank.Verify(m => m.ProcessPayment(It.IsAny<ProcessPaymentRequest>()), Times.Once);
        }

        [TestMethod]
        public void WhenPaymentProcessedThenReturnPaymentId()
        {
            Mock<IBank> mockBank = new Mock<IBank>();
            Mock<IProcessPaymentRepository> mockRepo = new Mock<IProcessPaymentRepository>();

            var unit = new ProcessPaymentService(mockBank.Object, mockRepo.Object);

            var paymentIdReturned = unit.ProcessPayment(IntegrationTests.ValidPaymentRequest());

            Assert.IsNotNull(paymentIdReturned);
        }
    }
}
