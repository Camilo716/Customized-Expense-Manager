using CEM.Views;
using System.Collections.Generic;
using System.Linq;
using Cem.Api.Models;
using CemApi.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class ClientCEM
{
    public ClientCEM() { }

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

        HttpClient client = new HttpClient();
        await client.PostAsync("http://localhost:5178/api/transaction", httpContent);
    }

    public static async Task ShowMonthlyReport()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:5178/api/category");
        
        string categoriesJson = response.Content.ReadAsStringAsync().Result;
        IEnumerable<Category> categories = JsonConvert
            .DeserializeObject<IEnumerable<Category>>(categoriesJson);

        ITableUI tableUI = new ConsoleTableUI(categories.ToList());
        tableUI.DrawTable();
    }
}