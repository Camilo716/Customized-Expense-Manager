using CEM.Repositories;

using System.Collections.Generic;
using System.Linq;
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
            CategoryOfTransaction = category
        };

        _dbContext.Transactions.Add(transaction);
        _dbContext.SaveChanges();
    }

    public IEnumerable<Transaction> GetAllTransactionsByTypeAndCategory(RequestType TransactionType, Category category)
    {
        var transactions = _dbContext.Transactions.Where(t => t.TransactionType == TransactionType && t.CategoryOfTransaction == category);

        return transactions;
    }
}