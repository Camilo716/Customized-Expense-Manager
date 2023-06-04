using CEM.Repositories;
using CEM.Util;
using CEM.Models;
using CEM.Views;
using System.Collections.Generic;
using System.Linq;
using System;

public class CEManager
{
    private ITransactionRepository _transactionDataAccess {get;set;} 
    private ICategoryRepository _categoryDataAccess; 
    private ITransactionData _data;

    public CEManager(ITransactionRepository transactionDataAccess, ICategoryRepository categoryDataAccess)
    {
        _transactionDataAccess = transactionDataAccess;
        _categoryDataAccess = categoryDataAccess;
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

        ITableUI tableUI = new ConsoleTableUI(categoriesWithTransactions);

        tableUI.DrawTable();
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