using System.Net;
using CEM.Context;
using CEM.DataAccess;
using CEM.Repositories;
using CemApi.DTOs;
using CemApi.Models;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
        _config = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<DbCemContext>(
            opt => opt.UseSqlServer(_config.GetConnectionString("sqlserver-docker"))
        );

        services.AddScoped<Transaction>();
        services.AddScoped<ICategoryRepository, EFCategoryDataAccess>();
        services.AddScoped<IAllCategoriesRepository, EFCategoryDataAccess>();
        services.AddScoped<ITransactionRepository, EFTransactionDataAccess>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void ConfigureMiddlewares(IApplicationBuilder app, IWebHostEnvironment webHostEnv)
    {
        if(webHostEnv.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoint => 
        {
            endpoint.MapControllers();
        });
    }
}