using Api.Cem.Tests.Common.HttpHelper;
using Cem.Api.Common;
using CemApi.DTOs;
using CemApi.DTOs.Reports.MonthlyBalance;
using IntegrationTests.Helpers;
using Microsoft.VisualBasic;

namespace IntegrationTests;

public partial class EnpointsTests
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    [Fact]
    public async Task ClientGenerateMonthlyReportTest()
    {
        HttpClient client = _factory.CreateClient();
        await ClientSaveSomeTransactions(client);

        HttpResponseMessage response = await client.GetAsync("/api/Balance/MonthlyBalanceReport");

        response.EnsureSuccessStatusCode();
        MonthlyBalanceReport monthlyBalanceReport = await ModelUtilities.GetModelFromHttpResponseAsync<MonthlyBalanceReport>(response);
        MonthlyBalanceReport expectedReport = BuildExpectedMonthlyBalanceReport();
        Assert.Equivalent(expectedReport, monthlyBalanceReport);
    }

    private async Task ClientSaveSomeTransactions(HttpClient client)
    {
        HttpContent transaction1 = TransactionUtilities.GetTransactionHttpContent(
            new TransactionDTO { 
                Category = "Category 1", Description = "Transaction 1 desc", Amount = "50", RequestType = TransactionType.Income }
        );
        HttpContent transaction2 = TransactionUtilities.GetTransactionHttpContent(
            new TransactionDTO { 
                Category = "Category 1", Description = "Transaction 2 desc", Amount = "10", RequestType = TransactionType.Expense }
        );
        HttpContent transaction3 = TransactionUtilities.GetTransactionHttpContent(
            new TransactionDTO { Category = "Category 1", Description = "Transaction 3 desc", Amount = "20", RequestType = TransactionType.Income }
        );
        HttpContent transaction4 = TransactionUtilities.GetTransactionHttpContent(
            new TransactionDTO { Category = "Category 2", Description = "Transaction 2 desc", Amount = "40", RequestType = TransactionType.Income }
        );

        await client.PostAsync("/api/transaction", transaction1);
        await client.PostAsync("/api/transaction", transaction2);
        await client.PostAsync("/api/transaction", transaction3);
        await client.PostAsync("/api/transaction", transaction4);
    }

    public MonthlyBalanceReport BuildExpectedMonthlyBalanceReport()
    {
        return new MonthlyBalanceReport {
            MonthlyBalancesPerCategory = new List<BalancePerCategory>() {
                new (){
                    Category = "Category 1",
                    Earned = 70,
                    Spent = 10
                },
                new (){
                    Category = "Category 2",
                    Earned = 40,
                    Spent = 0,
                }
            },
            TotalSpent = 10,
            TotalEarned = 110,
            Date = new DateOnly(2023, 12, 1)
        };
    }
}
