using System;
using System.Threading.Tasks;
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
        private readonly Mock<IBank> _mockBank = new Mock<IBank>();
        private readonly Mock<IProcessPaymentRepository> _mockRepo = new Mock<IProcessPaymentRepository>();
        private readonly Mock<ILogger<ProcessPaymentService>> _mockLogger = new Mock<ILogger<ProcessPaymentService>>();
        private readonly Mock<ICreditCardValidator> _mockValidator = new Mock<ICreditCardValidator>();

        [TestMethod]
        public async Task WhenPaymentProcessedThenBankApiIsCalled()
        {
            var unit = GetProcessPaymentService();

            await unit.ProcessPayment(ProcessPaymentServiceIntegrationTests.ValidPaymentRequest());

            _mockBank.Verify(m => m.ProcessPayment(It.IsAny<ProcessPaymentRequest>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenPaymentProcessedThenReturnPaymentId()
        {
            var unit = GetProcessPaymentService();

            var paymentIdReturned = await unit.ProcessPayment(ProcessPaymentServiceIntegrationTests.ValidPaymentRequest());

            Assert.IsNotNull(paymentIdReturned);
        }

        [TestMethod]
        public async Task WhenCVVMissingThenReturnClientError()
        {
            var unit = new ProcessPaymentService(_mockLogger.Object, _mockBank.Object, _mockRepo.Object, new CreditCardValidator());
            var processPaymentRequest = ProcessPaymentServiceIntegrationTests.ValidPaymentRequest();
            processPaymentRequest.CreditCard.CVV = 0;

            await Assert.ThrowsExceptionAsync<ArgumentException>(() => unit.ProcessPayment(processPaymentRequest));
        }

        private ProcessPaymentService GetProcessPaymentService()
        {
            return new ProcessPaymentService(_mockLogger.Object, _mockBank.Object, _mockRepo.Object, _mockValidator.Object);
        }
    }
}
