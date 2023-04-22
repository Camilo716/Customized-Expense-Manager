using System.Collections.Generic;

namespace CEM.Util;

public class TransactionData : ITransactionData
{   
    private RequestType _requestType = RequestType.Invalid;
    private string? _category;
    private string? _description;
    private string? _amount; 
    
    public void setData(string category, string description,  string amount)
    {
        _category = category;
        _description = description;
        _amount = amount;
    }

    public void SetRequestType(RequestType requestType)
    {
        _requestType = requestType;
    }

    public RequestType getRequestType()
    {
        return _requestType;
    }

    public string GetCategory()
    {
        return _category;
    }

    public string GetDescription()
    {
        return _description;
    }

    public string GetAmount()
    {
        return _amount;
    }
}

public interface ITransactionData
{  
    void setData(string category, string description, string value);
    void SetRequestType(RequestType requestType);
    string GetCategory();
    string GetDescription();
    string GetAmount();
    RequestType getRequestType();
}
