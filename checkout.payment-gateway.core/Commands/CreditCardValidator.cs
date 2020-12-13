using System;
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
                RuleFor(x => x).NotNull();
                RuleFor(x => x.Amount).GreaterThan(0);
                RuleFor(x => x.Currency).NotNull();
                RuleFor(x => x.Currency).NotEmpty();
                RuleFor(x => x.Currency).Must(x => NMoney.Iso4217.CurrencySet.Instance.TryParse(x) != null).When(x => x.Currency != null);

                RuleFor(x => x.CreditCard).NotNull();
                RuleFor(x => x.CreditCard.CVV).GreaterThan(99).When(x => x.CreditCard != null);
                RuleFor(x => x.CreditCard.Name).NotEmpty().When(x => x.CreditCard != null);
                RuleFor(x => x.CreditCard.Name).Must(x => !string.IsNullOrWhiteSpace(x)).When(x => x.CreditCard != null);

                RuleFor(x => x.CreditCard.ExpiryYear).Must(x => x >= DateTime.Now.Year).When(x => x.CreditCard != null);
                RuleFor(x => x.CreditCard.ExpiryMonth).GreaterThanOrEqualTo(1).When(x => x.CreditCard != null);
                RuleFor(x => x.CreditCard.ExpiryMonth).LessThanOrEqualTo(12).When(x => x.CreditCard != null);
            }
        }
    }
}