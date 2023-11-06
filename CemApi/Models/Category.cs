namespace CemApi.Models;

public class Category
{
    public int Id { get; set; }
    public string Name {get;set;}
    
    public virtual ICollection<Transaction> TransactionsInCategory {get;set;}
}