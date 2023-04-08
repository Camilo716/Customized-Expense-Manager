namespace CEM.Tests.Mocks;

using CEM.Repositories;
using CEM.Models;
using System.Collections.Generic;

public class IncomeMock : IIncomeRepository
{
    private List<IncomeModel> _incomes;
    
    
    public IncomeMock()
    {
        _incomes = new List<IncomeModel>
        {
            new IncomeModel{},
            new IncomeModel{},
            new IncomeModel{},
            new IncomeModel{},
        };
    }

    public void createIncome()
    {
        
    }
}