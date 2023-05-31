using System;
using CEM.Util;
using CEM.Context;
using CEM.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("./appsettings.json")
    .Build();

var connectionString = configuration.GetConnectionString("CEM");
var optionsBuilder = new DbContextOptionsBuilder<DbCemContext>();
optionsBuilder.UseSqlServer(connectionString);


using (var dbContext = new DbCemContext(optionsBuilder.Options))
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
}



