namespace CEM.Repositories;

using CemApi.Models;
using CemApi.Util;

public interface ITransactionRepository
{
    void AddTransaction(string Description, float Amount, RequestType TransactionType, Category category);
}