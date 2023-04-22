namespace CEM.Repositories;

using CEM.Util;
using CEM.Models;
using System.Collections.Generic;

public interface ITransactionRepository
{
    void AddTransaction(string description, float amount, RequestType transactionType, CategoryModel category);
    List<TransactionModel> GetAllTransactionsByTypeAndCategory(RequestType transactionType, CategoryModel category);
}