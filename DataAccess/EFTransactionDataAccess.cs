using CEM.Context;
using CEM.Models;
using CEM.Util;
using CEM.Repositories;

using System.Collections.Generic;
using System.Linq;

namespace CEM.DataAccess;

public class EFTransactionDataAccess : ITransactionRepository
{
    private readonly DbCemContext _dbContext;

    public EFTransactionDataAccess(DbCemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddTransaction(string Description, float Amount, RequestType TransactionType, CategoryModel category)
    {
        TransactionModel transaction = new TransactionModel
        {
            Description = Description,
            Amount = Amount,
            TransactionType = TransactionType,
            CategoryOfTransaction = category
        };

        _dbContext.Transactions.Add(transaction);
        _dbContext.SaveChanges();
    }

    public IEnumerable<TransactionModel> GetAllTransactionsByTypeAndCategory(RequestType TransactionType, CategoryModel category)
    {
        var transactions = _dbContext.Transactions.Where(t => t.TransactionType == TransactionType && t.CategoryOfTransaction == category);

        return transactions;
    }
}