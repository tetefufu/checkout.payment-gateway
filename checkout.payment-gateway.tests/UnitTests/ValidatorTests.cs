using checkout.payment_gateway.core.Commands;
using checkout.payment_gateway.core.Commands.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace checkout.payment_gateway.tests.UnitTests
{
    [TestClass]
    public class ValidatorTests
    {
        [DataRow(1, "GBP", "X X", 1234567887654321, 100, 2050, 13)]
        [DataRow(1, "GBP", "X X", 1234567887654321, 100, 1990, 1)]
        [DataRow(1, "GBP", "X X", 1234567887654321, 99, 2050, 1)]
        [DataRow(1, "GBP", " ", 1234567887654321, 100, 2050, 1)]
        [DataRow(1, "GB", "X X", 1234567887654321, 100, 2050, 1)]
        [DataRow(0, "GBP", "X X", 1234567887654321, 100, 2050, 1)]
        [TestMethod]
        public void GivenInvalidProcessPaymentRequest_ReturnValidationException(int amount, string currency, string name, long cardNumber, int CVV, int expiryYear, int expiryMonth)
        {
            var request = CreateProcessPaymentRequest(amount, currency, name, cardNumber, CVV, expiryYear, expiryMonth);

            var validator = new CreditCardValidator();

            Assert.ThrowsException<FluentValidation.ValidationException>(() => validator.Validate(request));
        }

        [DataRow(1, "GBP", "X X", 1234567887654321, 100, 2050, 1)]
        [TestMethod]
        public void GivenValidProcessPaymentRequest_ReturnVoid(int amount, string currency, string name, long cardNumber, int CVV, int expiryYear, int expiryMonth)
        {
            var request = CreateProcessPaymentRequest(amount, currency, name, cardNumber, CVV, expiryYear, expiryMonth);

            var validator = new CreditCardValidator();

            validator.Validate(request);
        }

        private ProcessPaymentRequest CreateProcessPaymentRequest(in int amount, string currency, string name, in long cardNumber, in int cvv, in int expiryYear, in int expiryMonth)
        {
            return new ProcessPaymentRequest
            {
                Amount = amount,
                Currency = currency,
                CreditCard = new CreditCard
                {
                    Name = name,
                    CardNumber = cardNumber,
                    CVV = cvv,
                    ExpiryYear = expiryYear,
                    ExpiryMonth = expiryMonth
                }
            };
        }
    }
}
