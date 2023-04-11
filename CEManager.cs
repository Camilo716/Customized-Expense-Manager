using CEM.Repositories;
using CEM.Util;
using CEM.Models;
using System.Collections.Generic;
public class CEManager
{
    public ITransactionRepository TransactionDataAccess {get;set;} 
    private ICategoryRepository _categoryDataAccess; 
    private readonly RequestType _requestType;
    private readonly Dictionary<string, string> _transactionData;

    public CEManager
    (
        ITransactionRepository transactionDataAccess,
        ICategoryRepository categoryDataAccess, 
        RequestType requestType, 
        Dictionary<string, string> transactionData
    )
    {
        TransactionDataAccess = transactionDataAccess;
        _categoryDataAccess = categoryDataAccess;
        _requestType = requestType;
        _transactionData =  transactionData;
    }

    public void MakeTransaction()
    {
        TryCreateCategory();
        TransactionDataAccess.AddTransaction
        (
            _transactionData["description"],
            float.Parse(_transactionData["value"]),
            _requestType,
            _transactionData["category"]
        );   
    }

    private void TryCreateCategory()
    {
        if (CategoryAlreadyExist() == false)
        {
            _categoryDataAccess.CreateNewCategory(_transactionData["category"]);
        }
    }

    private bool CategoryAlreadyExist()
    {
        List<string> allCategories = _categoryDataAccess.GetAllCategoriesNames();
        
        for (int category = 0; category < allCategories.Count ; category++)
        {
            if (allCategories[category] == _transactionData["category"])
            {
                return true;
            }
        }
        return false;
    }
}