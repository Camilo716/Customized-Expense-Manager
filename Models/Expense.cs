namespace CEM.Models;

public class ExpenseModel
{
    string description {get;set;}
    int amount {get;set;}
    CategoryModel CategoryID {get;set;}
}