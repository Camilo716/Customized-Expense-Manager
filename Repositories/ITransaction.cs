namespace CEM.Repositories;

using System.Collections.Generic;

public interface ITransactionRepository<T>
{
    void addTransaction(string description, float amount, string CategoryID);
    List<T> getAllTransactionsByCategoryID(string categoryID);
}