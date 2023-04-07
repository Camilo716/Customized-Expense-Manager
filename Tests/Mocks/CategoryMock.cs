namespace CEM.Tests.Mocks;

using CEM.Repositories;
using CEM.Models;
using System.Collections.Generic;

public class CategoryMock : ICategoryRepository
{
    private List<CategoryModel> _categories;
    
    
    public CategoryMock()
    {
        _categories = new List<CategoryModel>
        {
            new CategoryModel{},
            new CategoryModel{},
            new CategoryModel{},
            new CategoryModel{},
        };


    }
}