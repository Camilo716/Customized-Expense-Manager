namespace CEM.Repositories;

using CEM.Models;
using System.Collections.Generic;
public interface ICategoryRepository
{
    void CreateNewCategory(string name);
    IEnumerable<CategoryModel> GetAllCategories();
    CategoryModel GetCategoryByName(string categoryName);
}