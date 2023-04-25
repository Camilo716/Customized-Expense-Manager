namespace CEM.Repositories;

using CEM.Util;
using CEM.Models;
using System.Collections.Generic;

public interface ITransactionRepository
{
    void AddTransaction(string Description, float Amount, RequestType TransactionType, CategoryModel category);
    List<TransactionModel> GetAllTransactionsByTypeAndCategory(RequestType TransactionType, CategoryModel category);
}