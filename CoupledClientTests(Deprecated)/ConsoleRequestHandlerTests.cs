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
        RequestType.Expense
        )
    ]
    [InlineData
        (
        new string[]{"--income","exCategory","exDescription","10000"},
        RequestType.Income
        )
    ]
    [InlineData
        (
        new string[]{"--report"},
        RequestType.Report
        )
    ]
    [InlineData
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
        Assert.Equal(expectedRequestType, operationType);
    }
}