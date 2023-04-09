namespace CEM.Tests.Mocks;

using CEM.Repositories;
using CEM.Models;
using System.Collections.Generic;
using System;
using System.Linq;

public class IncomeMock : ITransactionRepository<IncomeModel>
{
    private List<IncomeModel> _incomes;
    
    
    public IncomeMock()
    {
        _incomes = new List<IncomeModel>
        {
            new IncomeModel{incomeID = Guid.NewGuid(), description = "Fuel", amount = 500, CategoryID = "Transport"},
            new IncomeModel{incomeID = Guid.NewGuid(), description = "Courses", amount = 500, CategoryID = "Education"}
        };
    }

    public void addTransaction(string _description, float _amount, string _CategoryID)
    {
        _incomes.Add(
            new IncomeModel{
                description = _description, 
                amount = _amount,
                CategoryID = _CategoryID
            }
        );
    }

    public List<IncomeModel> getAllTransactionsByCategoryID(string _categoryID)
    {
        List<IncomeModel> incomesByCategory = _incomes.Where(income=>income.CategoryID == _categoryID).ToList();

        return incomesByCategory;
    }


}