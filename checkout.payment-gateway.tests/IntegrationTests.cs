using checkout.payment_gateway.api;
using checkout.payment_gateway.core;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Shouldly;
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

            var request = new PaymentDto
            {
                Amount = 1.00m
            };

            var response = await client.PostAsync(
                "/ProcessPayment", 
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            ((int)response.StatusCode).ShouldBe(200);
        }
    }

    public class APIWebApplicationFactory : WebApplicationFactory<Startup>
    {
    }
}
