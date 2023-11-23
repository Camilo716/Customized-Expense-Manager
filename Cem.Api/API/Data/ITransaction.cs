namespace CEM.Repositories;

using Cem.Api.Models;
using Cem.Api.Common;

public interface ITransactionRepository
{
    void AddTransaction(string Description, float Amount, TransactionType TransactionType, Category category);
}