using CemApi.Util;

namespace CemApi.Models;

public class Transaction
{
    public Guid TransactionID {get;set;}
    public string CategoryID {get;set;}

    public string Description {get;set;}
    public float Amount {get;set;}
    public RequestType TransactionType{get;set;}

    public  virtual Category CategoryOfTransaction {get;set;}
}