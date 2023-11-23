using Cem.Api.Common;

namespace CemApi.DTOs;

public interface ITransactionData
{  
    void SetData(string category, string Description, string value);
    void SetRequestType(TransactionType requestType);
    string GetCategory();
    string GetDescription();
    string GetAmount();
    TransactionType GetRequestType();
}