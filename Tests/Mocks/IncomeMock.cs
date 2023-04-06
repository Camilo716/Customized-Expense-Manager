namespace CEM.Tests.Mocks;

using CEM.Repositories;
using CEM.Models;
using System.Collections.Generic;

public class IncomeMock : ICategoryRepository
{
    private List<IncomeModel> _categories;
    
    
    public IncomeMock()
    {
        _categories = new List<IncomeModel>
        {
            new IncomeModel{},
            new IncomeModel{},
            new IncomeModel{},
            new IncomeModel{},
        };
    }
}