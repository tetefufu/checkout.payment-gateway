using checkout.payment_gateway.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using System;

namespace checkout.payment_gateway.tests
{
    [TestClass]
    public class PaymentServiceIntegrationTests
    {
        [TestMethod]
        public void GivenPaymentProcessed_WhenProcessAndGetPayment_ThenPaymentDetailsReturned()
        {
            Mock<IBank> mockBank = new Mock<IBank>();
            var processPaymentService = new ProcessPaymentService(mockBank.Object, new ProcessPaymentRepository());
            var paymentService = new PaymentService(new Repository());

            var paymentIdReturned = processPaymentService.ProcessPayment(IntegrationTests.ValidPaymentRequest());
            var payment = paymentService.GetPayment(paymentIdReturned);

            payment.PaymentId.ShouldBe(paymentIdReturned);
        }
    }
}