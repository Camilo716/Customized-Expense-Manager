using CEM.Util;
using CemApi.DTOs;
using CemApi.Util;

namespace CEM.Tests;

public class ConsoleRequestHandlerTests
{
    [Theory]
    [InlineData
        (
        new string[]{"--expense", "eCategory", "eDescription","100"},
        TransactionType.Expense
        )
    ]
    [InlineData
        (
        new string[]{"--income","exCategory","exDescription","10000"},
        TransactionType.Income
        )
    ]
    [InlineData
        (
        new string[]{"--report"},
        TransactionType.Report
        )
    ]
    [InlineData
        (
        new string[]{"--income","eCategory","12341"},
        TransactionType.Invalid
        )
    ]
    public void ValidateRequest(string[] args, TransactionType expectedRequestType)
    {
        var requestHandler = new ConsoleRequestHandler(args);

        requestHandler.ValidateRequest();

        ITransactionData transactionData = requestHandler.GetTransactionData();
        var operationType = transactionData.GetRequestType();
        Assert.Equal(expectedRequestType, operationType);
    }
}