using System;
using checkout.payment_gateway.core.Commands.DTO;

namespace checkout.payment_gateway.core.Commands
{
    public class CreditCardValidator : ICreditCardValidator
    {
        public void Validate(CreditCard creditCard)
        {
            if (creditCard.CVV < 100)
            {
                throw new ArgumentException("CVV must be three numbers");
            }
        }
    }
}