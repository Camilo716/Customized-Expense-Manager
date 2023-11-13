using System.Text.Json.Serialization;
using CEM.Context;
using CEM.DataAccess;
using CEM.Repositories;
using CemApi.Data.Dapper;
using CemApi.Services;
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
        services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddDbContext<DbCemContext>(
            opt => opt.UseSqlServer(_config.GetConnectionString("sqlserver_docker"))
        );

        services.AddScoped<TransactionService>();
        services.AddScoped<CategoryService>();
        services.AddScoped<ICategoryRepository>(provider =>
        {
            return new DapperCategoryRepository(_config.GetConnectionString("sqlserver_docker")!);
        });
        services.AddScoped<IAllCategoriesRepository, EFCategoryDataAccess>();
        services.AddScoped<ITransactionRepository, EFTransactionDataAccess>();

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