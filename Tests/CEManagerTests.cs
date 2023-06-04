using NUnit.Framework;
using CEM.Tests.Context;
using CEM.Util;
using CEM.DataAccess;
using CEM.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CEM.Repositories;

namespace CEM.Tests;

public class CEManagerTests
{

    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void CreateTransactionInNewCategoryTest()
    {
        var options = new DbContextOptionsBuilder<DbCemContext>()
            .UseInMemoryDatabase("InMemoryDatabase")
            .Options;

        using (var dbContext = new InMemoryDbContext(options))
        {
            dbContext.Database.EnsureCreated();     


            ITransactionData transactionData = CreateTransactionData("NewCategory" ,"transactionDescription", "1000", RequestType.Income);
            CEManager manager =  CreateManager(dbContext);

            manager.MakeTransaction(transactionData);

            var createdCategory = dbContext.Categories.FirstOrDefault(c => c.Name == "NewCategory");
            var transactionsInCategory = createdCategory?.TransactionsInCategory.FirstOrDefault(t =>
                t.Description == "transactionDescription" &&
                t.Amount == 1000);
            Assert.NotNull(transactionsInCategory);


            dbContext.Database.EnsureDeleted();
        }
    }

    private ITransactionData CreateTransactionData(string category, string description, string amount, RequestType requestType)
    { 
        ITransactionData transactionData = new TransactionData();
        transactionData.SetData(category ,description, amount);
        transactionData.SetRequestType(requestType);

        return transactionData;
    }

    private CEManager CreateManager(InMemoryDbContext dbContext)
    {
        ITransactionRepository transactionRepository = new EFTransactionDataAccess(dbContext);
        ICategoryRepository categoryRepository= new EFCategoryDataAccess(dbContext);
        var manager = new CEManager(transactionRepository, categoryRepository);

        return manager;
    }
}
