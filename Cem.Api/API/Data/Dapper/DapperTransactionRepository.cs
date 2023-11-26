using System.Data;
using Cem.Api.Models;
using CEM.Repositories;
using Dapper;

namespace CemApi.Data.Dapper;

public class DapperTransactionRepository : ITransactionRepository
{
    private readonly DapperDbManager _dapperDbManager;

    public DapperTransactionRepository(DapperDbManager dapperDbManager)
    {
        _dapperDbManager = dapperDbManager;
    }

    public void SaveTransaction(Transaction transaction)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Description", transaction.Description);
        parameters.Add("Amount", transaction.Amount);
        parameters.Add("TransactionType", transaction.TransactionType);
        parameters.Add("Date", transaction.Date);
        parameters.Add("CategoryId", transaction.CategoryId);

        _ = _dapperDbManager.ExecuteStoredProcedure("InsertTransaction", parameters).Result;
    }
}