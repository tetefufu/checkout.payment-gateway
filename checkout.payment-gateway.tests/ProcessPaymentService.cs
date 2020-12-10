using checkout.payment_gateway.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace checkout.payment_gateway.tests
{
    [TestClass]
    public class ProcessPaymentServiceTest
    {
        [TestMethod]
        public void WhenPaymentProcessedThenBankApiIsCalled()
        {
            Mock<IBank> mockBank = new Mock<IBank>();

            var unit = new ProcessPaymentService(mockBank.Object);

            unit.ProcessPayment(IntegrationTests.ValidPaymentRequest());

            mockBank.Verify(m => m.ProcessPayment(It.IsAny<PaymentDto>()), Times.Once);
        }

        [TestMethod]
        public void WhenPaymentProcessedThenReturnPaymentIdFromBank()
        {
            Mock<IBank> mockBank = new Mock<IBank>();
            var paymentId = "a";
            mockBank.Setup(m => m.ProcessPayment(It.IsAny<PaymentDto>())).Returns(paymentId);

            var unit = new ProcessPaymentService(mockBank.Object);

            var paymentIdReturned = unit.ProcessPayment(IntegrationTests.ValidPaymentRequest());

            paymentIdReturned.ShouldBe(paymentId);
        }
    }
}
