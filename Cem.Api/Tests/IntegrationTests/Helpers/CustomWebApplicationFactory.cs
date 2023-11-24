using ApiTests.Stubs;
using Cem.Api.DateManagement;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Helpers;

public class CustomWebApplicationFactory<TProgram>
 : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureServices(services =>
        {
            ServiceDescriptor? dateManagerServiceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IDateManager));

            services.AddScoped<IDateManager, DateManagerStub>();
        });
    }
}