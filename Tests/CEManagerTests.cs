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
    public void createTransactionInNewCategoryTest()
    {  
        var transactionData = new Dictionary<string, string>()
        {
            {"category", "NewCategory"},
            {"description", "IncomeDescription"},
            {"value", "1000"},
        };
        CEManager manager = createCEManager(RequestType.Income, transactionData);
        

        manager.makeTransaction();


        List<TransactionModel> incomesExpected = new List<TransactionModel>
        {
            new TransactionModel{ description = "IncomeDescription", amount = 1000, transactionType = RequestType.Income, CategoryID = "NewCategory"},
        };

        List<TransactionModel> incomes = manager.transactionDataAccess.
            getAllTransactionsByTypeAndCategoryID(
                RequestType.Income, transactionData["category"]
            );

        var totalDataExpected = getAllDataFromAllIncomes(incomesExpected);
        var totalDataRecieved = getAllDataFromAllIncomes(incomes);

        Assert.That(totalDataRecieved, Is.EquivalentTo(totalDataExpected));
    }
    
    private ArrayList getAllDataFromAllIncomes(List<TransactionModel> incomes)
    {
        var allData = new ArrayList();

        for (int i = 0; i < incomes.Count; i++)
        {
            allData.Add(incomes[i].description);
            allData.Add(incomes[i].CategoryID);  
        }

        return allData;
    }

    private CEManager createCEManager(RequestType _requestType, Dictionary<string,string> _transactionData)
    {
        ITransactionRepository transactionMock = new TransactionMock();
        CategoryMock categoryMock = new CategoryMock();
        CEManager manager = new CEManager(transactionMock, categoryMock, _requestType, _transactionData);

        return manager;
    }
}
