using System.Data;
using CEM.Repositories;
using CemApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CemApi.Data.Dapper;

public class DapperCategoryRepository : ICategoryRepository
{
    private readonly IDbConnection _connection;

    public DapperCategoryRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public void CreateNewCategory(string name)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Name", name);

        _connection.Execute (
            "InsertCategory",
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<Category> GetAllCategories()
    {
        IEnumerable<Category> categories = _connection.Query<Category>(
            "GetAllCategories",
            commandType: CommandType.StoredProcedure
        );

        return categories;
    }

    public Category GetCategoryByName(string categoryName)
    {
        var parameters = new DynamicParameters();
        parameters.Add("CategoryName", categoryName);

        Category? category = _connection.QuerySingleOrDefault<Category> (
            "GetCategoryByName",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return category!;
    }
}