using NUnit.Framework;
using CEM.Util;

namespace CEM.Tests;

public class ConsoleRequestHandlerTests
{
    [TestCase
        (
        new string[]{"--expense", "eCategory", "eDescription","100"},
        RequestType.Expense
        )
    ]
    [TestCase
        (
        new string[]{"--income","exCategory","exDescription","10000"},
        RequestType.Income
        )
    ]
    [TestCase
        (
        new string[]{"--report"},
        RequestType.Report
        )
    ]
    [TestCase
        (
        new string[]{"--income","eCategory","12341"},
        RequestType.Invalid
        )
    ]
    public void ValidateRequest(string[] args, RequestType expectedRequestType)
    {
        var requestHandler = new ConsoleRequestHandler(args);

        requestHandler.ValidateRequest();

        ITransactionData transactionData = requestHandler.GetTransactionData();
        var operationType = transactionData.GetRequestType();
        Assert.That(operationType, Is.EqualTo(expectedRequestType));
    }
}