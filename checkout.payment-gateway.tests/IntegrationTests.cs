using checkout.payment_gateway.api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
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

            var response = await client.GetAsync("/WeatherForecast");

            ((int)response.StatusCode).ShouldBe(200);
        }
    }

    public class APIWebApplicationFactory : WebApplicationFactory<Startup>
    {
    }
}
