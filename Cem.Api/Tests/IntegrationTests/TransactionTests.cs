using CemApi.DTOs;
using CemApi.Util;
using IntegrationTests.Helpers;

namespace IntegrationTests;

public partial class EnpointsTests 
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    [Fact]
    public async Task PostTransactionWithUnexistingCategoryTest()
    {
        var client = _factory.CreateClient();
        TransactionDTO transactionDto = new TransactionDTO 
        {
            Category = "New category",
            Description = "Transaction descripcion",
            Amount = "1000",
            RequestType = TransactionType.Income
        };
        HttpContent transaction = TransactionUtilities.GetTransactionHttpContent(transactionDto);

        HttpResponseMessage response = await client.PostAsync("/api/transaction", transaction);

        response.EnsureSuccessStatusCode();
    }
}