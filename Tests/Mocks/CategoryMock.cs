using CEM.Repositories;
using CEM.Models;
using System.Collections.Generic;
using System.Linq;

namespace CEM.Tests.Mocks;

public class CategoryMock : ICategoryRepository
{
    private List<CategoryModel> _categories;
    
    
    public CategoryMock()
    {
        _categories = new List<CategoryModel>
        {
            new CategoryModel{name = "Entertaiment"},
            new CategoryModel{name = "Education"},
            new CategoryModel{name = "Transport"}
        };
    }

    public void CreateNewCategory(string _name)
    {
        _categories.Add(new CategoryModel{name = _name});
    }

    public List<CategoryModel> GetAllCategories()
    {
        List<CategoryModel> categories = new List<CategoryModel>(); 

        for (int categ = 0; categ < _categories.Count; categ++)
        {
            categories.Add(_categories[categ]);
        }

        return categories;
    }

    public CategoryModel GetCategoryByName(string name)
    {
        var category = _categories
            .SingleOrDefault(c => c.name == name);
        
        return category;
    }
}