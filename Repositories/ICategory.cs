namespace CEM.Repositories;

using CEM.Models;
using System.Collections.Generic;
public interface ICategoryRepository
{
    void CreateNewCategory(string name);
    List<CategoryModel> GetAllCategories();
    CategoryModel GetCategoryByName(string categoryName);
}