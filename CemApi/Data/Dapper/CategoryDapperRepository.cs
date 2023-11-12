using CEM.Repositories;
using CemApi.Models;

namespace CemApi.Data.Dapper;

public class CategoryDapperRepository : ICategoryRepository
{
    public void CreateNewCategory(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetAllCategories()
    {
        throw new NotImplementedException();
    }

    public Category GetCategoryByName(string categoryName)
    {
        throw new NotImplementedException();
    }
}