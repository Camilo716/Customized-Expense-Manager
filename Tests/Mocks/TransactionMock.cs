using CEM.Repositories;
using CEM.Models;
using CEM.Util;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CEM.Tests.Mocks;

public class TransactionMock : ITransactionRepository
{
    private List<TransactionModel> _transactions;

    private List<CategoryModel> _categoryModels;

    public TransactionMock()
    {
        ICategoryRepository categoryMock = new CategoryMock();
        _categoryModels = categoryMock.GetAllCategories();

        _transactions = new List<TransactionModel>
        {
            new TransactionModel
            {
                TransactionID = Guid.NewGuid(), 
                Description = "Fuel", Amount = 500, 
                TransactionType = RequestType.Expense, 
                CategoryOfTransaction = _categoryModels[2] // Transport
            },
            new TransactionModel
            {
                TransactionID = Guid.NewGuid(), 
                Description = "Courses", 
                Amount = 500,
                TransactionType = RequestType.Income, 
                CategoryOfTransaction = _categoryModels[1] // Education
            }
        };
    }

    public void AddTransaction(string Description, float Amount, RequestType TransactionType, CategoryModel category)
    {
        _transactions.Add(
            new TransactionModel{
                Description = Description, 
                Amount = Amount,
                TransactionType = TransactionType,
                CategoryOfTransaction = category
            }
        );
    }

    public List<TransactionModel> GetAllTransactionsByTypeAndCategory(RequestType TransactionType, CategoryModel category)
    {
        List<TransactionModel> transactionsByTypeAndCategoryID = _transactions
            .Where
            (
                transaction=>transaction.TransactionType == TransactionType && transaction.CategoryOfTransaction.name == category.name 
            ).ToList();

        return transactionsByTypeAndCategoryID;
    }


}