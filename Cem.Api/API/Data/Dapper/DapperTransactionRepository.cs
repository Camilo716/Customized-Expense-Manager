using System.Data;
using Cem.Api.Models;
using CEM.Repositories;
using Dapper;

namespace CemApi.Data.Dapper;

public class DapperTransactionRepository : ITransactionRepository
{
    private readonly IDbConnection _connection;

    public DapperTransactionRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public void SaveTransaction(Transaction transaction)
    {
        _connection.Open();
        var parameters = new DynamicParameters();
        parameters.Add("Description", transaction.Description);
        parameters.Add("Amount", transaction.Amount);
        parameters.Add("TransactionType", transaction.TransactionType);
        parameters.Add("Date", transaction.Date);
        parameters.Add("CategoryId", transaction.CategoryId);

        _connection.Execute (
            "InsertTransaction",
            parameters,
            commandType: CommandType.StoredProcedure);
        _connection.Close();   
    }
}