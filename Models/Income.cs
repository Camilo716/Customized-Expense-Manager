namespace CEM.Models;

using System;

public class IncomeModel
{
    public Guid incomeID {get;set;}
    public string description {get;set;}
    public int amount {get;set;}
    public string CategoryID {get;set;}
}