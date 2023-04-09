using CEM.Repositories;
using CEM.Util;
using CEM.Models;
using System.Collections.Generic;
public class CEManager
{
    public ITransactionRepository<ExpenseModel> expenseDataAccess; 
    public ITransactionRepository<IncomeModel> incomeDataAccess; 
    private ICategoryRepository categoryDataAccess; 
    private RequestType requestType;
    private Dictionary<string, string> transactionData;

    public CEManager
    (
        ITransactionRepository<ExpenseModel> _expenseDataAccess, 
        ITransactionRepository<IncomeModel> _incomeDataAccess, 
        ICategoryRepository _categoryDataAccess, 
        RequestType _requestType, 
        Dictionary<string, string> _transactionData
    )
    {
        expenseDataAccess = _expenseDataAccess;
        incomeDataAccess = _incomeDataAccess;
        categoryDataAccess = _categoryDataAccess;
        requestType = _requestType;
        transactionData =  _transactionData;
    }

    public void proccessTransaction()
    {
        if (requestType == RequestType.Income)
        {
            makeIncomeTransaction();
        }

    }

    private void makeIncomeTransaction()
    {
        tryCreateCategory();
        
        incomeDataAccess.addTransaction
        (
            transactionData["description"],
            float.Parse(transactionData["value"]),
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