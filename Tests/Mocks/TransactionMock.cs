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
    
    
    public TransactionMock()
    {
        _transactions = new List<TransactionModel>
        {
            new TransactionModel{transactionID = Guid.NewGuid(), description = "Fuel", amount = 500, CategoryID = "Transport"},
            new TransactionModel{transactionID = Guid.NewGuid(), description = "Courses", amount = 500, CategoryID = "Education"}
        };
    }

    public void addTransaction(string _description, float _amount, RequestType _transactionType, string _CategoryID)
    {
        _transactions.Add(
            new TransactionModel{
                description = _description, 
                amount = _amount,
                transactionType = _transactionType,
                CategoryID = _CategoryID
            }
        );
    }

    public List<TransactionModel> getAllTransactionsByTypeAndCategoryID(RequestType _transactionType, string _categoryID)
    {
        List<TransactionModel> transactionsByTypeAndCategoryID = _transactions.Where
            (
            transaction=>transaction.transactionType == _transactionType && transaction.CategoryID == _categoryID 
            ).ToList();

        return transactionsByTypeAndCategoryID;
    }


}