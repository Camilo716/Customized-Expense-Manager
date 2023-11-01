namespace CEM.Repositories;

using CemApi.Models;
using System.Collections.Generic;

public interface ICategoryRepository : IAllCategoriesRepository
{
    void CreateNewCategory(string name);
    Category GetCategoryByName(string categoryName);
}

public interface IAllCategoriesRepository
{
    IEnumerable<Category> GetAllCategories();    
}