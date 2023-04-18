using System.Collections.Generic;

namespace CEM.Util;

public class TransactionData : ITransactionData
{   
    private RequestType _requestType = RequestType.Invalid;
    private string _category;
    private string _description;
    private float amount; 

    private Dictionary<string, string> _transactionData = new Dictionary<string, string>()
    {
        {"category", ""},
        {"description", ""},
        {"value", ""},
    };

    public Dictionary<string, string> getTransData()
    {
        return _transactionData;
    }

    public void setData(string category, string description, string value)
    {
        _transactionData["category"] = category;
        _transactionData["description"] = description;
        _transactionData["value"] = value;
    }

    public void SetRequestType(RequestType requestType)
    {
        _requestType = requestType;
    }

    public RequestType getRequestType()
    {
        return _requestType;
    }
}

public interface ITransactionData
{
    Dictionary<string,string> getTransData();
    void setData(string category, string description, string value);
    void SetRequestType(RequestType requestType);
    RequestType getRequestType();
}
