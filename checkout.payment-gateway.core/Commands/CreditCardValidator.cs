using checkout.payment_gateway.core.Commands.DTO;
using FluentValidation;

namespace checkout.payment_gateway.core.Commands
{
    public class CreditCardValidator : ICreditCardValidator
    {
        private readonly CustomerValidator _validator = new CustomerValidator();

        public void Validate(ProcessPaymentRequest request)
        {
            _validator.ValidateAndThrow(request);
        }

        private class CustomerValidator : AbstractValidator<ProcessPaymentRequest>
        {
            public CustomerValidator()
            {
                RuleFor(x => x.Amount).GreaterThan(0);
                RuleFor(x => x.CreditCard).NotNull();
                RuleFor(x => x.CreditCard.CVV).GreaterThan(100).When(x => x.CreditCard != null);
            }
        }
    }
}