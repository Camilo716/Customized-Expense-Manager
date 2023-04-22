using System.Collections.Generic;

namespace CEM.Models;

public class CategoryModel
{
    public string name {get;set;}
    
    public virtual ICollection<TransactionModel> transactionsInCategory {get;set;}
}