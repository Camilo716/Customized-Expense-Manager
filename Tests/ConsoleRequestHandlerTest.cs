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
        var requestAnalizer = new ConsoleRequestHandler(expenseArgs);

        var operationtype = requestAnalizer.getRequestType();

        Assert.That(operationtype, Is.EqualTo(RequestType.Expense));
    }
}