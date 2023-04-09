using CEM.Repositories;
using CEM.Util;
using CEM.Models;
using System.Collections.Generic;
public class CEManager
{
    public ITransactionRepository transactionDataAccess; 
    private ICategoryRepository categoryDataAccess; 
    private RequestType requestType;
    private Dictionary<string, string> transactionData;

    public CEManager
    (
        ITransactionRepository _incomeDataAccess, 
        ICategoryRepository _categoryDataAccess, 
        RequestType _requestType, 
        Dictionary<string, string> _transactionData
    )
    {
        transactionDataAccess = _incomeDataAccess;
        categoryDataAccess = _categoryDataAccess;
        requestType = _requestType;
        transactionData =  _transactionData;
    }

    public void makeTransaction()
    {
        tryCreateCategory();
        transactionDataAccess.addTransaction
        (
            transactionData["description"],
            float.Parse(transactionData["value"]),
            requestType,
            transactionData["category"]
        );   
    }

    private void tryCreateCategory()
    {
        if (categoryAlreadyExist() == false)
        {
            categoryDataAccess.createNewCategory(transactionData["category"]);
        }
    }

    private bool categoryAlreadyExist()
    {
        List<string> allCategories = categoryDataAccess.getAllCategoriesNames();
        
        for (int cat = 0; cat < allCategories.Count ; cat++)
        {
            if (allCategories[cat] == transactionData["category"])
            {
                return true;
            }
        }
        return false;
    }
}