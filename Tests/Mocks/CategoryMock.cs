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

    public void CreateNewCategory(string _name)
    {
        _categories.Add(new CategoryModel{name = _name});
    }

    public List<string> GetAllCategoriesNames()
    {
        var categoriesNames = new List<string>();

        for (int categ = 0; categ < _categories.Count; categ++)
        {
            categoriesNames.Add(_categories[categ].name);
        }

        return categoriesNames;
    }
}