using System;
using checkout.payment_gateway.core.Commands;
using checkout.payment_gateway.core.Commands.Data;
using checkout.payment_gateway.core.Commands.DTO;
using checkout.payment_gateway.tests.IntegrationTests;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace checkout.payment_gateway.tests.UnitTests
{
    [TestClass]
    public class ProcessPaymentServiceTest
    {
        private Mock<IBank> mockBank = new Mock<IBank>();
        private Mock<IProcessPaymentRepository> mockRepo = new Mock<IProcessPaymentRepository>();
        private Mock<ILogger<ProcessPaymentService>> mockLogger = new Mock<ILogger<ProcessPaymentService>>();
        private Mock<ICreditCardValidator> mockValidator = new Mock<ICreditCardValidator>();

        [TestMethod]
        public void WhenPaymentProcessedThenBankApiIsCalled()
        {
            var unit = GetProcessPaymentService();

            unit.ProcessPayment(ProcessPaymentServiceIntegrationTests.ValidPaymentRequest());

            mockBank.Verify(m => m.ProcessPayment(It.IsAny<ProcessPaymentRequest>()), Times.Once);
        }

        [TestMethod]
        public void WhenPaymentProcessedThenReturnPaymentId()
        {
            var unit = GetProcessPaymentService();

            var paymentIdReturned = unit.ProcessPayment(ProcessPaymentServiceIntegrationTests.ValidPaymentRequest());

            Assert.IsNotNull(paymentIdReturned);
        }

        [TestMethod]
        public void WhenCVVMissingThenReturnClientError()
        {
            var unit = new ProcessPaymentService(mockLogger.Object, mockBank.Object, mockRepo.Object, new CreditCardValidator());
            var processPaymentRequest = ProcessPaymentServiceIntegrationTests.ValidPaymentRequest();
            processPaymentRequest.CreditCard.CVV = 0;

            Assert.ThrowsException<ArgumentException>(() => unit.ProcessPayment(processPaymentRequest));
        }

        private ProcessPaymentService GetProcessPaymentService()
        {
            return new ProcessPaymentService(mockLogger.Object, mockBank.Object, mockRepo.Object, mockValidator.Object);
        }
    }
}
