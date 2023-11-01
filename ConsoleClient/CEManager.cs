using CEM.Repositories;
using CEM.Views;
using System.Collections.Generic;
using System.Linq;
using CemApi.Models;
using CemApi.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

public class ClientCEM
{
    private ICategoryRepository _categoryDataAccess; 

    public ClientCEM(ICategoryRepository categoryDataAccess)
    {
        _categoryDataAccess = categoryDataAccess;
    }

    public void MakeTransaction(ITransactionData transactionData)
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
        client.PostAsync("http://localhost:5178/api/transaction", httpContent);
    }

    public void ShowMonthlyReport()
    {
        List<Category> categoriesWithTransactions = _categoryDataAccess.GetAllCategories().ToList();
        ITableUI tableUI = new ConsoleTableUI(categoriesWithTransactions);
        tableUI.DrawTable();
    }
}