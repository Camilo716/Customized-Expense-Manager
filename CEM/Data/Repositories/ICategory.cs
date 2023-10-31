namespace CEM.Repositories;

using CEM.Models;
using System.Collections.Generic;

public interface ICategoryRepository : IAllCategoriesRepository
{
    void CreateNewCategory(string name);
    CategoryModel GetCategoryByName(string categoryName);
}

public interface IAllCategoriesRepository
{
    IEnumerable<CategoryModel> GetAllCategories();    
}