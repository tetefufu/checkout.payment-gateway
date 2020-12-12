using checkout.payment_gateway.core;
using checkout.payment_gateway.core.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace checkout.payment_gateway.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "checkout.payment_gateway.api", Version = "v1" });
            });
            services.AddScoped<IProcessPaymentService, ProcessPaymentService>();
            services.AddScoped<IProcessPaymentRepository, ProcessPaymentRepository>();
            services.AddScoped<IBank, FakeBank>();
            services.AddScoped<IPastPaymentService, PastPaymentService>();
            services.AddScoped<IPastPaymentRepository, PastPaymentReponse>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "checkout.payment_gateway.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
