namespace CEM.Repositories;

using CEM.Models;
using CemApi.Util;

public interface ITransactionRepository
{
    void AddTransaction(string Description, float Amount, RequestType TransactionType, CategoryModel category);
}