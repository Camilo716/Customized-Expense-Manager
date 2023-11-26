namespace CEM.Repositories;

using Cem.Api.Models;

public interface ITransactionRepository
{
    void SaveTransaction(Transaction transaction);
}