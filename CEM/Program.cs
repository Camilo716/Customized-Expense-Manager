using System;
using CEM.Util;
using CEM.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CemApi.Util;
using CEM.Context;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("./appsettings.json")
    .Build();

var connectionString = configuration.GetConnectionString("CEM");
var optionsBuilder = new DbContextOptionsBuilder<DbCemContext>()
    .UseSqlServer(connectionString)
    .Options;


using (var dbContext = new DbCemContext(optionsBuilder))
{
    dbContext.Database.EnsureCreated();     
    var transactionDataAccess = new EFTransactionDataAccess(dbContext);
    var categoryDataAccess = new EFCategoryDataAccess(dbContext);

    var requestHandler = new ConsoleRequestHandler(args);
    var cemanager = new CEManager(transactionDataAccess, categoryDataAccess);

    requestHandler.ValidateRequest();
    ITransactionData transactionData = requestHandler.GetTransactionData();

    bool validRequest = transactionData.GetRequestType() != RequestType.Invalid;
    bool notReport = transactionData.GetRequestType() != RequestType.Report;
    
    if (validRequest & notReport)
    {
        cemanager.MakeTransaction(transactionData);
    }
    else
    {
        cemanager.ShowMonthlyReport();
    }

    dbContext.Database.EnsureDeleted();
}



