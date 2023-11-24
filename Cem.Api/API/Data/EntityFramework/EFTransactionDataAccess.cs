using CEM.Repositories;
using Cem.Api.Common;
using Cem.Api.Models;
using CEM.Context;

namespace CEM.DataAccess;

public class EFTransactionDataAccess : ITransactionRepository
{
    private readonly DbCemContext _dbContext;

    public EFTransactionDataAccess(DbCemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveTransaction(Transaction transaction)
    {
        _dbContext.Transactions.Add(transaction);
        _dbContext.SaveChanges();
    }

    public IEnumerable<Transaction> GetAllTransactionsByTypeAndCategory(TransactionType TransactionType, Category category)
    {
        var transactions = _dbContext.Transactions.Where(t => t.TransactionType == TransactionType && t.Category == category);

        return transactions;
    }
}