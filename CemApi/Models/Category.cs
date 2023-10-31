namespace CemApi.Models;

public class Category
{
    public string Name {get;set;}
    
    public virtual ICollection<Transaction> TransactionsInCategory {get;set;}

    public Category(string name)
    {
        Name = name;
    }
}