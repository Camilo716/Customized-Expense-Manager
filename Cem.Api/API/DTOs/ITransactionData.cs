using CemApi.Util;

namespace CemApi.DTOs;

public interface ITransactionData
{  
    void SetData(string category, string Description, string value);
    void SetRequestType(RequestType requestType);
    string GetCategory();
    string GetDescription();
    string GetAmount();
    RequestType GetRequestType();
}