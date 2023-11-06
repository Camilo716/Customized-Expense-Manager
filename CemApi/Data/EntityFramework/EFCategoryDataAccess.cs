using CEM.Repositories;
using Microsoft.EntityFrameworkCore;
using CemApi.Models;
using CEM.Context;

namespace CEM.DataAccess;

public class EFCategoryDataAccess : ICategoryRepository
{
    private readonly DbCemContext _dbContext;

    public EFCategoryDataAccess(DbCemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateNewCategory(string name)
    {
        _dbContext.Add(new Category() { Name = name });
        _dbContext.SaveChanges();
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _dbContext.Categories.Include(c => c.TransactionsInCategory);
    }

    public Category GetCategoryByName(string categoryName)
    {
        return  _dbContext.Categories.FirstOrDefault(c => c.Name == categoryName)!;
    }
}