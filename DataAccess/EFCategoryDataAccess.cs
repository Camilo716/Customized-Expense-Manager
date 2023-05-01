using System.Collections.Generic;
using CEM.Models;
using CEM.Repositories;
using Microsoft.EntityFrameworkCore;
using CEM.Context;
using System.Linq;

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
        _dbContext.Add(new CategoryModel(){Name = name});
        _dbContext.SaveChanges();
    }

    public IEnumerable<CategoryModel> GetAllCategories()
    {
        return _dbContext.Categories;
    }

    public CategoryModel GetCategoryByName(string categoryName)
    {
        // Only can exist one category with that name
        return  _dbContext.Categories.Where(c => c.Name == categoryName).ToList()[0];
    }
}