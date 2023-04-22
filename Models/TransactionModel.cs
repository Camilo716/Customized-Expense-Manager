namespace CEM.Models;

using CEM.Util;
using System;

public class TransactionModel
{
    public Guid transactionID {get;set;}
    public string description {get;set;}
    public float amount {get;set;}
    public RequestType transactionType{get;set;}
    public  virtual string CategoryID {get;set;}
}