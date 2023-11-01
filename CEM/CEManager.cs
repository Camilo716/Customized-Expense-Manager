using CEM.Repositories;
using CEM.Views;
using System.Collections.Generic;
using System.Linq;
using CemApi.Models;
using CemApi.DTOs;
using CemApi.Services;

public class CEManager
{
    private ITransactionRepository _transactionDataAccess {get;set;} 
    private ICategoryRepository _categoryDataAccess; 
    private readonly TransactionService _transactionService;

    public CEManager(ITransactionRepository transactionDataAccess, ICategoryRepository categoryDataAccess)
    {
        _transactionDataAccess = transactionDataAccess;
        _categoryDataAccess = categoryDataAccess;
        _transactionService = new TransactionService(_transactionDataAccess, _categoryDataAccess);
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

        _transactionService.MakeTransaction(transactionDTO);
    }

    public void ShowMonthlyReport()
    {
        List<Category> categoriesWithTransactions = _categoryDataAccess.GetAllCategories().ToList();
        ITableUI tableUI = new ConsoleTableUI(categoriesWithTransactions);
        tableUI.DrawTable();
    }
}