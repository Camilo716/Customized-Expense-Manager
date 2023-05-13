using NUnit.Framework;
using CEM.Tests.Mocks;
using CEM.Util;
using CEM.Models;
using CEM.Repositories;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;

namespace CEM.Tests;

public class CEManagerTests
{

    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void CreateTransactionInNewCategoryTest()
    {
        // Arrange
        ITransactionData transactionData1 = new TransactionData();
        transactionData1.SetData("NewCategory" ,"transactionDescription", "1000");
        transactionData1.SetRequestType(RequestType.Income);
        CEManager manager = CreateCEManager();
        

        // Act
        manager.MakeTransaction(transactionData1);


        // Assert
        List<TransactionModel> transactionsExpected = new List<TransactionModel>
        {
            new TransactionModel
            {
                Description = "transactionDescription",
                Amount = 1000,
                TransactionType = RequestType.Income,
                CategoryOfTransaction = new CategoryModel("NewCategory")
            }
        };

        List<TransactionModel> transactionsReceived = manager._transactionDataAccess.
            GetAllTransactionsByTypeAndCategory(
                RequestType.Income, manager._categoryDataAccess.GetCategoryByName(manager._data.GetCategory())
            ).ToList();

        ArrayList totalDataExpected = GetDataFromAllTransactions(transactionsExpected);
        ArrayList totalDataReceived = GetDataFromAllTransactions(transactionsReceived);

        Assert.That(totalDataReceived, Is.EquivalentTo(totalDataExpected));
    }

    private ArrayList GetDataFromAllTransactions(List<TransactionModel> transactions)
    {
        var allData = new ArrayList();

        for (int i = 0; i < transactions.Count; i++)
        {
            allData.Add(transactions[i].Description);
            allData.Add(transactions[i].CategoryOfTransaction.Name); 
        }

        return allData;
    }
    
    private CEManager CreateCEManager()
    {
        ITransactionRepository transactionMock = new TransactionMock();
        ICategoryRepository categoryMock = new CategoryMock();
        CEManager manager = new CEManager(transactionMock, categoryMock);

        return manager;
    }

}
