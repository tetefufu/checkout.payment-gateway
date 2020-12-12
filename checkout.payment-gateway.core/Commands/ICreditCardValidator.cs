using checkout.payment_gateway.core.Commands.DTO;

namespace checkout.payment_gateway.core.Commands
{
    public interface ICreditCardValidator
    {
        void Validate(CreditCard creditCard);
    }
}