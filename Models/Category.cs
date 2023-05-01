using System.Collections.Generic;

namespace CEM.Models;

public class CategoryModel
{
    public string Name {get;set;}
    
    public virtual ICollection<TransactionModel> TransactionsInCategory {get;set;}
}