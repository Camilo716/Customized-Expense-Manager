namespace CEM.Tests.Mocks;

using CEM.Repositories;
using CEM.Models;
using System.Collections.Generic;
using System;

public class IncomeMock : IIncomeRepository
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

    public void createIncome()
    {
        
    }
}