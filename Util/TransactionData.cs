using System.Collections.Generic;

namespace CEM.Util;

public class TransactionData : ITransactionData
{
    private Dictionary<string, string> _transactionData = new Dictionary<string, string>()
    {
        {"category", ""},
        {"description", ""},
        {"value", ""},
    };

    public Dictionary<string, string> getTransactionData()
    {
        return _transactionData;
    }

    public void setData(string category, string description, string value)
    {
        _transactionData["category"] = category;
        _transactionData["description"] = description;
        _transactionData["value"] = value;
    }
}

public interface ITransactionData
{
    Dictionary<string,string> getTransactionData();
    void setData(string category, string description, string value);
}
