using CEM.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
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
            ServiceDescriptor? dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<DbCemContext>));
            services.Remove(dbContextDescriptor!); 

            services.AddDbContext<DbCemContext>(options => 
            {
                options.UseInMemoryDatabase(new Guid().ToString());
            });
        });
    }
}