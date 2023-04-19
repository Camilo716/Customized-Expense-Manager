using CEM.Repositories;
using CEM.Util;
using CEM.Models;
using System.Collections.Generic;
public class CEManager
{
    public ITransactionRepository _transactionDataAccess {get;set;} 
    private ICategoryRepository _categoryDataAccess; 
    public readonly ITransactionData _data;

    public CEManager
    (
        ITransactionRepository transactionDataAccess,
        ICategoryRepository categoryDataAccess, 
        ITransactionData transactionData
    )
    {
        _transactionDataAccess = transactionDataAccess;
        _categoryDataAccess = categoryDataAccess;
        _data = transactionData;
    }

    public void MakeTransaction()
    {
        TryCreateCategory();
        _transactionDataAccess.AddTransaction
        (
            _data.GetDescription(),
            float.Parse(_data.GetAmount()),
            _data.getRequestType(),
            _data.GetCategory()
        );   
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
        List<string> allCategories = _categoryDataAccess.GetAllCategoriesNames();
        
        for (int category = 0; category < allCategories.Count ; category++)
        {
            if (allCategories[category] == _data.GetCategory())
            {
                return true;
            }
        }
        return false;
    }
}