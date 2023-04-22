namespace CEM.Tests.Mocks;

using CEM.Repositories;
using CEM.Models;
using CEM.Util;
using System.Collections.Generic;
using System;
using System.Linq;

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
                transactionID = Guid.NewGuid(), 
                description = "Fuel", amount = 500, 
                transactionType = RequestType.Expense, 
                CategoryOfTransaction = _categoryModels[2] // Transport
            },
            new TransactionModel
            {
                transactionID = Guid.NewGuid(), 
                description = "Courses", 
                amount = 500,
                transactionType = RequestType.Income, 
                CategoryOfTransaction = _categoryModels[1] // Education
            }
        };
    }

    public void AddTransaction(string description, float amount, RequestType transactionType, CategoryModel category)
    {
        _transactions.Add(
            new TransactionModel{
                description = description, 
                amount = amount,
                transactionType = transactionType,
                CategoryOfTransaction = category
            }
        );
    }

    public List<TransactionModel> GetAllTransactionsByTypeAndCategory(RequestType transactionType, CategoryModel category)
    {
        List<TransactionModel> transactionsByTypeAndCategoryID = _transactions
            .Where
            (
                transaction=>transaction.transactionType == transactionType && transaction.CategoryOfTransaction.name == category.name 
            ).ToList();

        return transactionsByTypeAndCategoryID;
    }


}