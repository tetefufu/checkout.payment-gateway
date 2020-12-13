using checkout.payment_gateway.core.Commands;
using checkout.payment_gateway.core.Commands.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace checkout.payment_gateway.tests.UnitTests
{
    [TestClass]
    public class ValidatorTests
    {
        [DataRow(0)]
        [TestMethod]
        public void ValidateProcessPaymentRequest(int amount)
        {
            var request = new ProcessPaymentRequest
            {
                Amount = amount
            };

            var validator = new CreditCardValidator();

            Assert.ThrowsException<FluentValidation.ValidationException>(() => validator.Validate(request));
        }
    }
}
