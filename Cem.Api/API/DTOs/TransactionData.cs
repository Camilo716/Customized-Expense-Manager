using CemApi.Util;
using CemApi.DTOs;

namespace CEM.Util;

public class TransactionData : ITransactionData
{   
    private TransactionType _requestType = TransactionType.Invalid;
    private string _category;
    private string _Description;
    private string _Amount;
    
    public void SetData(string category, string Description,  string Amount)
    {
        _category = category;
        _Description = Description;
        _Amount = Amount;
    }

    public void SetRequestType(TransactionType requestType)
    {
        _requestType = requestType;
    }

    public TransactionType GetRequestType()
    {
        return _requestType;
    }

    public string GetCategory()
    {
        return _category;
    }

    public string GetDescription()
    {
        return _Description;
    }

    public string GetAmount()
    {
        return _Amount;
    }
}

