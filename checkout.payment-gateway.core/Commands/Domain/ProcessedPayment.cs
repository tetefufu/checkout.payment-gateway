﻿using System;
using checkout.payment_gateway.core.Commands.DTO;

namespace checkout.payment_gateway.core.Commands.Domain
{
    public class ProcessedPayment
    {
        public ProcessedPayment(ProcessPaymentRequest payment, BankResponse bankReponse)
        {
            PaymentId = Guid.NewGuid();
            MaskedCreditCardNumber = GetMaskedCreditCardNumber(payment.CreditCard);
            Currency = payment.Currency;
            Amount = payment.Amount;
            BankResponse = bankReponse;
        }

        private string GetMaskedCreditCardNumber(CreditCard creditCard)
        {
            return creditCard.CardNumber.ToString().Substring(12);
        }

        public Guid PaymentId { get; private set; }
        public string MaskedCreditCardNumber { get; private set; }
        public string Currency { get; private set; }
        public decimal Amount { get; private set; }
        public BankResponse BankResponse { get; private set; }
    }
}
