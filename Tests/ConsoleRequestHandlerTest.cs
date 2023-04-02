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
        string[] incomeArgs = new string[]{
            "--expense",
            "eCategory",
            "eDescription",
            "100",
        };
        var requestAnalizer = new ConsoleRequestHandler(incomeArgs);

        var operationType = requestAnalizer.getRequestType();

        Assert.That(operationType, Is.EqualTo(RequestType.Expense));
    }

    [Test]
    public void validateIncomeRequest()
    {
        string[] incomeArgs = new string[]{
            "--income",
            "eCategory",
            "eDescription",
            "100"
        };

        var requestAnalizer = new ConsoleRequestHandler(incomeArgs);

        var operationType = requestAnalizer.getRequestType();

        Assert.That(operationType, Is.EqualTo(RequestType.Income));
    }
}