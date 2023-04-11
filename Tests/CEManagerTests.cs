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
        var transactionData = new Dictionary<string, string>()
        {
            {"category", "NewCategory"},
            {"description", "transactionDescription"},
            {"value", "1000"},
        };
        CEManager manager = CreateCEManager(RequestType.Income, transactionData);
        

        manager.MakeTransaction();


        List<TransactionModel> transactionsExpected = new List<TransactionModel>
        {
            new TransactionModel{
                description = "transactionDescription",
                amount = 1000,
                transactionType = RequestType.Income,
                CategoryID = "NewCategory"}
        };

        List<TransactionModel> transactionsReceived = manager.TransactionDataAccess.
            GetAllTransactionsByTypeAndCategoryID(
                RequestType.Income, transactionData["category"]
            );

        var totalDataExpected = GetDataFromAllTransactions(transactionsExpected);
        var totalDataReceived = GetDataFromAllTransactions(transactionsReceived);

        Assert.That(totalDataReceived, Is.EquivalentTo(totalDataExpected));
    }
 
    private ArrayList GetDataFromAllTransactions(List<TransactionModel> transactions)
    {
        var allData = new ArrayList();

        for (int i = 0; i < transactions.Count; i++)
        {
            allData.Add(transactions[i].description);
            allData.Add(transactions[i].CategoryID);  
        }

        return allData;
    }

    private CEManager CreateCEManager(RequestType _requestType, Dictionary<string,string> _transactionData)
    {
        ITransactionRepository transactionMock = new TransactionMock();
        CategoryMock categoryMock = new CategoryMock();
        CEManager manager = new CEManager(transactionMock, categoryMock, _requestType, _transactionData);

        return manager;
    }
}
