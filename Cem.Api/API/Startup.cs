using System.Data;
using System.Text.Json.Serialization;
using Cem.Api.DateManagement;
using Cem.Api.Models;
using CemApi.Data;
using CemApi.Data.Dapper;
using CemApi.Services;
using Microsoft.Data.SqlClient;

public class Startup
{
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
        _config = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        string _sqlServerCnxString = _config.GetConnectionString("sqlserver_docker")!;

        services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddTransient<IDbConnection>(
            provider => new SqlConnection(_sqlServerCnxString)
        );

        services.AddScoped<TransactionService>();
        services.AddScoped<CategoryService>();
        services.AddScoped<BalanceService>();

        services.AddTransient<IRepository<Category>, DapperCategoryRepository>();
        services.AddTransient<IRepository<Transaction>, DapperTransactionRepository>();
        services.AddTransient<IBalanceRepository, DapperBalanceRepository>();

        services.AddTransient(
            provider => new DapperDbManager(_sqlServerCnxString)
        );

        services.AddScoped<IDateManager, DateManager>();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader() 
                    .AllowAnyMethod();
            });
        });
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