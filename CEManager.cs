using CEM.Repositories;
using CEM.Util;
using CEM.Models;
using System.Collections.Generic;

public class CEManager
{
    public ITransactionRepository _transactionDataAccess {get;set;} 
    public ICategoryRepository _categoryDataAccess; 
    public ITransactionData _data;

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
            _data.getRequestType(),
            _categoryDataAccess.GetCategoryByName(_data.GetCategory())
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
        List<CategoryModel> allCategories = _categoryDataAccess.GetAllCategories();
        
        for (int category = 0; category < allCategories.Count ; category++)
        {
            if (allCategories[category].name == _data.GetCategory())
            {
                return true;
            }
        }

        return false;
    }
}