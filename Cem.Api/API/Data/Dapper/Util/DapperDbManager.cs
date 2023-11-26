using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CemApi.Data.Dapper;

public class DapperDbManager
{
    private readonly string connectionString;

    public DapperDbManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async Task<int> ExecuteStoredProcedure(string storedProcedureName, DynamicParameters parameters)
    {
        using var _dbConnection = new SqlConnection(connectionString);
        _dbConnection.Open();

        int affectedRows = await _dbConnection.ExecuteAsync(
            storedProcedureName,
            parameters,
            commandType: CommandType.StoredProcedure);

        _dbConnection.Close();
        _dbConnection.Dispose();

        return affectedRows;
    }

    public async Task<IEnumerable<T>> ExecuteStoredProcedureReaderAsync<T>(string storedProcedureName, DynamicParameters parameters = null)
    {
        using var _dbConnection = new SqlConnection(connectionString);
        _dbConnection.Open();

        IEnumerable<T> records = await _dbConnection.QueryAsync<T>(
            storedProcedureName,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        _dbConnection.Close();
        _dbConnection.Dispose();

        return records;
    }
}

