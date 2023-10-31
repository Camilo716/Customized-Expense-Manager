using System.Collections.Generic;
using CEM.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
        _dbContext.Add(new Category(name));
        _dbContext.SaveChanges();
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _dbContext.Categories.Include(c => c.TransactionsInCategory);
    }

    public Category GetCategoryByName(string categoryName)
    {
        // Only can exist one category with that name
        return  _dbContext.Categories.Where(c => c.Name == categoryName).ToList()[0];
    }
}