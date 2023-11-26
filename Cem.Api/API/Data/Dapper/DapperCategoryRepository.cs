using System.Data;
using CEM.Repositories;
using Cem.Api.Models;
using Dapper;

namespace CemApi.Data.Dapper;

public class DapperCategoryRepository : ICategoryRepository
{
    private readonly DapperDbManager _dapperDbManager;

    public DapperCategoryRepository(DapperDbManager dapperDbManager)
    {
        _dapperDbManager = dapperDbManager;
    }

    public void CreateNewCategory(string name)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Name", name);

        _ = _dapperDbManager.ExecuteStoredProcedure("InsertCategory", parameters).Result;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _dapperDbManager.ExecuteStoredProcedureReaderAsync<Category>("GetAllCategories").Result;;
    }

    public Category GetCategoryByName(string categoryName)
    {
        var parameters = new DynamicParameters();
        parameters.Add("CategoryName", categoryName);

        return _dapperDbManager.ExecuteStoredProcedureReaderAsync<Category>(
            "GetCategoryByName", parameters).Result.FirstOrDefault()!;
    }
}