using CEM.Views;
using CemApi.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CemApi.DTOs.Reports.MonthlyBalance;

public class ClientCEM
{
    private const string API_URL = "http://localhost:5178/api/";

    public async static Task MakeTransaction(ITransactionData transactionData)
    {
        TransactionDTO transactionDTO = new TransactionDTO
        {
            Description = transactionData.GetDescription(),
            Amount = transactionData.GetAmount(),
            RequestType = transactionData.GetRequestType(),
            Category = transactionData.GetCategory(),
        };
        string jsonContent = JsonConvert.SerializeObject(transactionDTO);
        HttpContent httpContent = new StringContent(
            jsonContent, Encoding.UTF8, "application/json");

        var client = new HttpClient();
        await client.PostAsync($"{API_URL}transaction", httpContent);
    }

    public static async Task ShowMonthlyBalanceReport()
    {
        var client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync($"{API_URL}balance/MonthlyBalanceReport");
        
        string balanceJson = response.Content.ReadAsStringAsync().Result;
        MonthlyBalanceReport balance = JsonConvert
            .DeserializeObject<MonthlyBalanceReport>(balanceJson);

        ConsoleTableUI.DrawMonthlyBalanceReport(balance);
    }
}