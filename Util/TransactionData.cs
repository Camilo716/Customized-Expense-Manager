using System.Collections.Generic;

namespace CEM.Util;

public class TransactionData : ITransactionData
{   
    private RequestType _requestType = RequestType.Invalid;
    private string _category;
    private string _Description;
    private string _Amount; 
    
    public void SetData(string category, string Description,  string Amount)
    {
        _category = category;
        _Description = Description;
        _Amount = Amount;
    }

    public void SetRequestType(RequestType requestType)
    {
        _requestType = requestType;
    }

    public RequestType GetRequestType()
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

public interface ITransactionData
{  
    void SetData(string category, string Description, string value);
    void SetRequestType(RequestType requestType);
    string GetCategory();
    string GetDescription();
    string GetAmount();
    RequestType GetRequestType();
}
