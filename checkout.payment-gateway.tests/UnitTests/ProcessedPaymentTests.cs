using checkout.payment_gateway.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace checkout.payment_gateway.tests.UnitTests
{
    [TestClass]
    public class ProcessedPaymentTests
    {
        [TestMethod]
        public void CreateProcessedPayment()
        {
            string currency = "USD";
            decimal amount = 1.00m;
            BankStatusEnum paymentStatus = BankStatusEnum.Success;

            var processedPayment = new ProcessedPayment(new ProcessPaymentRequest
            {
                CreditCard = new CreditCard
                {
                    CardNumber = 1234567887654321
                },
                Currency = currency,
                Amount = amount
            },
            new BankResponse
            {
                PaymentStatus = paymentStatus
            });

            processedPayment.MaskedCreditCardNumber.ShouldBe("4321");
            processedPayment.Currency.ShouldBe(currency);
            processedPayment.Amount.ShouldBe(amount);
            processedPayment.BankResponse.PaymentStatus.ShouldBe(paymentStatus);
        }
    }
}