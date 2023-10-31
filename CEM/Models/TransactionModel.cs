namespace CEM.Models;

using CEM.Util;
using CemApi.Util;
using System;

public class TransactionModel
{
    public Guid TransactionID {get;set;}
    public string CategoryID {get;set;}

    public string Description {get;set;}
    public float Amount {get;set;}
    public RequestType TransactionType{get;set;}
    
    public  virtual CategoryModel CategoryOfTransaction {get;set;}
}