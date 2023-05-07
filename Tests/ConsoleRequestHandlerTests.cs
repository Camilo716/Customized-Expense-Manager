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
    public void ValidateExpenseRequest()
    {
        string[] expenseArgs = new string[]{
            "--expense",
            "eCategory",
            "eDescription",
            "100",
        };
        var requestHandler = new ConsoleRequestHandler(expenseArgs);

        requestHandler.ProcessRequest();

        ITransactionData transactionData = requestHandler.GetTransactionData();        
        var operationType = transactionData.GetRequestType();
        Assert.That(operationType, Is.EqualTo(RequestType.Expense));
    }

    [Test]
    public void ValidateIncomeRequest()
    {
        string[] expenseArgs = new string[]{
            "--income",
            "exCategory",
            "exDescription",
            "10000"
        };
        var requestHandler = new ConsoleRequestHandler(expenseArgs);

        requestHandler.ProcessRequest();

        ITransactionData transactionData = requestHandler.GetTransactionData();        
        var operationType = transactionData.GetRequestType();
        Assert.That(operationType, Is.EqualTo(RequestType.Income));
    }

    [Test]
    public void ValidateReportRequest()
    {
        string[] reportArgs = new string[]{
            "--report",
            "InCategory",
            "InDescription",
            "100"
        };
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

        requestHandler.ProcessRequest();

        ITransactionData transactionData = requestHandler.GetTransactionData();        
        var operationType = transactionData.GetRequestType();

        Assert.That(operationType, Is.EqualTo(RequestType.Invalid));      
    }

    [Test]
    public void InvalidArgumentTest()
    {  
        string[] invalidArgs = new string[]{
            "--income",
            "eCategory",
            "eDescription",
        };
        var requestHandler = new ConsoleRequestHandler(invalidArgs);

        requestHandler.ProcessRequest();

        ITransactionData transactionData = requestHandler.GetTransactionData();        
        var operationType = transactionData.GetRequestType();

        Assert.That(operationType, Is.EqualTo(RequestType.Invalid));      
    }

}