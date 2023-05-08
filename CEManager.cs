using CEM.Repositories;
using CEM.Util;
using CEM.Models;
using CEM.Views;
using System.Collections.Generic;
using System.Linq;

public class CEManager
{
    public ITransactionRepository _transactionDataAccess {get;set;} 
    public ICategoryRepository _categoryDataAccess; 
    private ITableUI _tableUI;
    public ITransactionData _data;

    public CEManager(ITransactionRepository transactionDataAccess, ICategoryRepository categoryDataAccess)
    {
        _transactionDataAccess = transactionDataAccess;
        _categoryDataAccess = categoryDataAccess;
        _tableUI = new ConsoleTableUI();
    }

    public void MakeTransaction(ITransactionData transactionData)
    {
        _data = transactionData;

        TryCreateCategory();
        
        _transactionDataAccess.AddTransaction
        (
            _data.GetDescription(),
            float.Parse(_data.GetAmount()),
            _data.GetRequestType(),
            _categoryDataAccess.GetCategoryByName(_data.GetCategory())
        );   
    }

    public void ShowMonthlyReport()
    {
        List<CategoryModel> categoriesWithTransactions = _categoryDataAccess.GetAllCategories().ToList();

        var categories = new List<string>();
        var earned = new List<float>();
        var spent = new List<float>();

        foreach (var category in categoriesWithTransactions)
        {
            categories.Add(category.Name);

            foreach (var transaction in category.TransactionsInCategory)
            {
                if (transaction.TransactionType == RequestType.Income)
                {
                    earned.Add(transaction.Amount);
                } else
                {
                    spent.Add(transaction.Amount);
                }
            }
        }
        
        _tableUI.DrawTable(categories.ToArray(), earned.ToArray(), spent.ToArray());
    }



    private void TryCreateCategory()
    {
        if (!CategoryAlreadyExist())
        {
            _categoryDataAccess.CreateNewCategory(_data.GetCategory());
        }
    }

    private bool CategoryAlreadyExist()
    {
        List<CategoryModel> allCategories = _categoryDataAccess.GetAllCategories().ToList();
        
        for (int category = 0; category < allCategories.Count ; category++)
        {
            if (allCategories[category].Name == _data.GetCategory())
            {
                return true;
            }
        }

        return false;
    }
}