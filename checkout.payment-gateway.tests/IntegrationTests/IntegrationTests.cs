﻿using checkout.payment_gateway.api;
using checkout.payment_gateway.core;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace checkout.payment_gateway.tests
{
    [TestClass]
    public class IntegrationTests
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTests()
        {
            _factory = new APIWebApplicationFactory();
        }

        [TestMethod]
        public async Task WhenClientProcessesPaymentThenResponseShouldBe200()
        {
            var client = _factory.CreateClient();
            ProcessPaymentRequest request = ValidPaymentRequest();

            var response = await client.PostAsync("/Payments", ToStringContent(request));

            ((int)response.StatusCode).ShouldBe(200);
            ProcessPaymentResponse processPaymentResponse = JsonConvert.DeserializeObject<ProcessPaymentResponse>(await response.Content.ReadAsStringAsync());
            processPaymentResponse.PaymentId.ShouldBeOfType<Guid>();

            response = await client.GetAsync($"/Payments/?paymentId={processPaymentResponse.PaymentId}");

            ((int)response.StatusCode).ShouldBe(200);
            PastPaymentResponse paymentDetailsDto = JsonConvert.DeserializeObject<PastPaymentResponse>(await response.Content.ReadAsStringAsync());
            paymentDetailsDto.PaymentId.ShouldBeOfType<Guid>();
        }

        private static StringContent ToStringContent(ProcessPaymentRequest request)
        {
            return new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        }

        public static ProcessPaymentRequest ValidPaymentRequest()
        {
            return new ProcessPaymentRequest
            {
                CreditCard = new CreditCard
                {
                    Name = "Joel",
                    CardNumber = 1234567887654321,
                    ExpiryYear = 10,
                    ExpiryMonth = 08
                },
                Amount = 1.00m
            };
        }
    }
}
