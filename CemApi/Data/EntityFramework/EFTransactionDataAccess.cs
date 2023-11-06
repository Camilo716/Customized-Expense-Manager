using CEM.Repositories;
using CemApi.Util;
using CemApi.Models;
using CEM.Context;

namespace CEM.DataAccess;

public class EFTransactionDataAccess : ITransactionRepository
{
    private readonly DbCemContext _dbContext;

    public EFTransactionDataAccess(DbCemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddTransaction(string Description, float Amount, RequestType TransactionType, Category category)
    {
        Transaction transaction = new Transaction
        {
            Description = Description,
            Amount = Amount,
            TransactionType = TransactionType,
            Category = category
        };

        _dbContext.Transactions.Add(transaction);
        _dbContext.SaveChanges();
    }

    public IEnumerable<Transaction> GetAllTransactionsByTypeAndCategory(RequestType TransactionType, Category category)
    {
        var transactions = _dbContext.Transactions.Where(t => t.TransactionType == TransactionType && t.Category == category);

        return transactions;
    }
}