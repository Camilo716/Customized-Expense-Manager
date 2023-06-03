namespace CEM.Repositories;

using CEM.Util;
using CEM.Models;

public interface ITransactionRepository
{
    void AddTransaction(string Description, float Amount, RequestType TransactionType, CategoryModel category);
}