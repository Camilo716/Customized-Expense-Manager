namespace CEM.Repositories;

using Cem.Api.Models;
using Cem.Api.Common;

public interface ITransactionRepository
{
    void SaveTransaction(Transaction transaction);
}