namespace CEM.Models;

using System;

public class ExpenseModel
{
    public Guid expenseID {get;set;}
    public string description {get;set;}
    public float amount {get;set;}
    public string CategoryID {get;set;}
}