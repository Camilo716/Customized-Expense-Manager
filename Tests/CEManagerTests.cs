using NUnit.Framework;
using CEM.Tests.Mocks;
using CEM.Util;
using CEM.Models;
using System.Collections.Generic;

namespace CEM.Tests;

/*
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
        
        manager.doTransaction();

   
        List<IncomeModel> incomes = manager.incomeMock.getAllIncomesByCategoryID();
        
        Assert.That()
    }
    

    private CEManager createCEManager(RequestType _requestType, Dictionary<string,string> _transactionData)
    {
        IncomeMock incomeMock = new IncomeMock();
        ExpenseMock expenseMock = new ExpenseMock();
        CategoryMock categoryMock = new CategoryMock();
        CEManager manager = new CEManager(incomeMock, expenseMock, categoryMock, _requestType, _transactionData);

        return manager;
    }
}
*/