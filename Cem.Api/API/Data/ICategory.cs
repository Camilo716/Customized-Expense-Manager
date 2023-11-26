namespace CEM.Repositories;

using Cem.Api.Models;
using System.Collections.Generic;

public interface ICategoryRepository
{
    void CreateNewCategory(string name);
    Category GetCategoryByName(string categoryName);
    IEnumerable<Category> GetAllCategories();    
}
