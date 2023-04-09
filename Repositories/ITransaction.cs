namespace CEM.Repositories;

using CEM.Util;
using CEM.Models;
using System.Collections.Generic;

public interface ITransactionRepository
{
    void addTransaction(string description, float amount, RequestType transactionType, string CategoryID);
    List<TransactionModel> getAllTransactionsByTypeAndCategoryID(RequestType transactionType, string categoryID);
}