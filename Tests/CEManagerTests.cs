using NUnit.Framework;
using CEM.Tests.Context;
using CEM.Util;
using CEM.DataAccess;
using CEM.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CEM.Tests;

public class CEManagerTests
{

    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void CreateTransactionInNewCategoryTest_()
    {
        var options = new DbContextOptionsBuilder<DbCemContext>()
            .UseInMemoryDatabase("InMemoryDatabase")
            .Options;

        using (var dbContext = new InMemoryDbContext(options))
        {
            dbContext.Database.EnsureCreated();     

            // Arrange 
            ITransactionData transactionData1 = new TransactionData();
            transactionData1.SetData("NewCategory" ,"transactionDescription", "1000");
            transactionData1.SetRequestType(RequestType.Income);
            var transactionDataAccess = new EFTransactionDataAccess(dbContext);
            var categoryDataAccess = new EFCategoryDataAccess(dbContext);
            CEManager manager = new CEManager(transactionDataAccess, categoryDataAccess);

            // Act
            manager.MakeTransaction(transactionData1);


            // Assert
            var createdCategory = dbContext.Categories.FirstOrDefault(c => c.Name == "NewCategory");
            var transactionsInCategory = createdCategory?.TransactionsInCategory.FirstOrDefault(t =>
                t.Description == "transactionDescription" &&
                t.Amount == 1000);

            Assert.NotNull(transactionsInCategory);

            dbContext.Database.EnsureDeleted();
        }
    }
}
