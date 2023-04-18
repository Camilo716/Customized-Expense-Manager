using NUnit.Framework;
using CEM.Util;

namespace CEM.Tests;

public class ConsoleRequestHandlerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void validateExpenseRequest()
    {
        string[] expenseArgs = new string[]{
            "--expense",
            "eCategory",
            "eDescription",
            "100",
        };
        var requestHandler = new ConsoleRequestHandler(expenseArgs);

        requestHandler.processRequest();

        ITransactionData transactionData = requestHandler.getTransactionData();        
        var operationType = transactionData.getRequestType();
        Assert.That(operationType, Is.EqualTo(RequestType.Expense));
    }

    [Test]
    public void validateIncomeRequest()
    {
        string[] expenseArgs = new string[]{
            "--income",
            "InCategory",
            "InDescription",
            "100"
        };
        var requestHandler = new ConsoleRequestHandler(expenseArgs);

        requestHandler.processRequest();

        ITransactionData transactionData = requestHandler.getTransactionData();        
        var operationType = transactionData.getRequestType();
        Assert.That(operationType, Is.EqualTo(RequestType.Income));
    }

    [Test]
    public void invalidRequestTest()
    {  
        string[] invalidRequest = new string[]{
            "InvalidRequest",
            "Category",
            "Description",
            "100"
        };
        var requestHandler = new ConsoleRequestHandler(invalidRequest);

        requestHandler.processRequest();

        ITransactionData transactionData = requestHandler.getTransactionData();        
        var operationType = transactionData.getRequestType();

        Assert.That(operationType, Is.EqualTo(RequestType.Invalid));      
    }

    [Test]
    public void invalidArgumentsTest()
    {  
        string[] invalidArgs = new string[]{
            "--income",
            "eCategory",
            "eDescription",
        };
        var requestHandler = new ConsoleRequestHandler(invalidArgs);

        requestHandler.processRequest();

        ITransactionData transactionData = requestHandler.getTransactionData();        
        var operationType = transactionData.getRequestType();

        Assert.That(operationType, Is.EqualTo(RequestType.Invalid));      
    }

}