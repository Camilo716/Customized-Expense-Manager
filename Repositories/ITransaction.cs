namespace CEM.Repositories;

using CEM.Util;
using CEM.Models;
using System.Collections.Generic;

public interface ITransactionRepository
{
    void AddTransaction(string description, float amount, RequestType transactionType, string CategoryID);
    List<TransactionModel> GetAllTransactionsByTypeAndCategoryID(RequestType transactionType, string categoryID);
}