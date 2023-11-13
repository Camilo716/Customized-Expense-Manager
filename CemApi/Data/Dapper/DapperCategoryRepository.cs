using System.Data;
using CEM.Repositories;
using CemApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CemApi.Data.Dapper;

public class DapperCategoryRepository : ICategoryRepository
{
    private readonly string _connectionString;

    public DapperCategoryRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void CreateNewCategory(string name)
    {
        using var connection = new SqlConnection(_connectionString);
        var parameters = new DynamicParameters();
        parameters.Add("Name", name);

        connection.Execute (
            "InsertCategory",
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<Category> GetAllCategories()
    {
        using var connection = new SqlConnection(_connectionString);

        IEnumerable<Category> categories = connection.Query<Category>(
            "GetAllCategories",
            commandType: CommandType.StoredProcedure
        );

        return categories;
    }

    public Category GetCategoryByName(string categoryName)
    {
        using var connection = new SqlConnection(_connectionString);
        var parameters = new DynamicParameters();
        parameters.Add("CategoryName", categoryName);

        Category? category = connection.QuerySingleOrDefault<Category> (
            "GetCategoryByName",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return category!;
    }
}