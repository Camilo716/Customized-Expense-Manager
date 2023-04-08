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
            new CategoryModel{name = "Entertaiment"},
            new CategoryModel{name = "Education"},
            new CategoryModel{name = "Transporte"}
        };
    }

    public void createNewCategory()
    {
        //_categories.Add(new CategoryModel{});
    }

}