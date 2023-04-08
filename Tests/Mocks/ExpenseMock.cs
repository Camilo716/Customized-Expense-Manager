namespace CEM.Tests.Mocks;

using CEM.Repositories;
using CEM.Models;
using System.Collections.Generic;

public class ExpenseMock : IExpenseRepository
{
    private List<ExpenseModel> _expenses;
    
    
    public ExpenseMock()
    {
        _expenses = new List<ExpenseModel>
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