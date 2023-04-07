namespace CEM.Tests.Mocks;

using CEM.Repositories;
using CEM.Models;
using System.Collections.Generic;

public class ExpenseMock : IExpenseRepository
{
    private List<ExpenseModel> _categories;
    
    
    public ExpenseMock()
    {
        _categories = new List<ExpenseModel>
        {
            new ExpenseModel{},
            new ExpenseModel{},
            new ExpenseModel{},
            new ExpenseModel{},
        };
    }

    public void createExpense()
    {

    }
}