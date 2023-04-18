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
        ITransactionData transactionData1 = new TransactionData();
        transactionData1.setData("NewCategory" ,"transactionDescription", "1000");
        Dictionary<string, string> data =  transactionData1.getTransData();

        CEManager manager = CreateCEManager(RequestType.Income, data);
        

        manager.MakeTransaction();


        List<TransactionModel> transactionsExpected = new List<TransactionModel>
        {
            new TransactionModel
            {
                description = "transactionDescription",
                amount = 1000,
                transactionType = RequestType.Income,
                CategoryID = "NewCategory"
            }
        };

        List<TransactionModel> transactionsReceived = manager._transactionDataAccess.
            GetAllTransactionsByTypeAndCategoryID(
                RequestType.Income, data["category"]
            );

        ArrayList totalDataExpected = GetDataFromAllTransactions(transactionsExpected);
        ArrayList totalDataReceived = GetDataFromAllTransactions(transactionsReceived);

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
