using NUnit.Framework;

namespace CEM.Tests;

public class CategoryTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void validate_spent_transaction()
    {
        ICategoryRepository transaction = new CategoryService()
        {
            name = "Invest"
        };

        


        Assert.That(tableGenerated, tableExpected);
    }
}