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
    public void createIncomeInNewCategoryTest()
    {  
        var transactionData = new Dictionary<string, string>()
        {
            {"category", "NewCategory"},
            {"description", "IncomeDescription"},
            {"value", "1000"},
        };
        CEManager manager = createCEManager(RequestType.Income, transactionData);
        

        manager.proccessTransaction();


        List<IncomeModel> incomesExpected = new List<IncomeModel>
        {
            new IncomeModel{ description = "IncomeDescription", amount = 1000, CategoryID = "NewCategory"},
        };
        List<IncomeModel> incomes = manager.incomeDataAccess.getAllTransactionsByCategoryID(transactionData["category"]);
        var totalDataExpected = getAllDataFromAllRegister(incomesExpected);
        var totalDataRecieved = getAllDataFromAllRegister(incomes);

        Assert.That(totalDataRecieved, Is.EquivalentTo(totalDataExpected));
    }
    
    private ArrayList getAllDataFromAllRegister(List<IncomeModel> incomes)
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
        ITransactionRepository<IncomeModel> incomeMock = new IncomeMock();
        ITransactionRepository<ExpenseModel> expenseMock = new ExpenseMock();
        CategoryMock categoryMock = new CategoryMock();
        CEManager manager = new CEManager(expenseMock, incomeMock, categoryMock, _requestType, _transactionData);

        return manager;
    }
}
