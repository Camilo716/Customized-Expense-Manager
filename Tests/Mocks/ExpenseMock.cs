namespace CEM.Tests.Mocks;

using System;
using CEM.Repositories;
using CEM.Models;
using System.Collections.Generic;

public class ExpenseMock : ITransactionRepository<ExpenseModel>
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

    public void addTransaction(string _description, float _amount, string _CategoryID)
    {
        _expenses.Add(
            new ExpenseModel{
                description = _description, 
                amount = _amount,
                CategoryID = _CategoryID
            }
        );
    }

    public List<ExpenseModel> getAllTransactionsByCategoryID(string _categoryID)
    {
        return _expenses;
    }
}