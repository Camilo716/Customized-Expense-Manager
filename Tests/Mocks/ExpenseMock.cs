namespace CEM.Tests.Mocks;

using System;
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
            new ExpenseModel{expenseID = Guid.NewGuid(), description = "Movies", amount = 400, CategoryID = "Entertaiment"},
            new ExpenseModel{expenseID = Guid.NewGuid(), description = "Books", amount = 300, CategoryID = "Education"},
        };
    }

    public void createExpense()
    {

    }
}