using Cem.Api.Models;
using Cem.Api.Common;

public class SampleDataSeeder
{
    public static List<Category> SeedCategories()
    {
        var categories = new List<Category>
        {
            new() { Id = 1, Name = "Food" },
            new() { Id = 2, Name = "Groceries" },
            new() { Id = 3, Name = "Entertainment" },
            new() { Id = 4, Name = "Company" },
        };

        return categories;
    }

    public static List<Transaction> SeedTransactions()
    {
        var transactions = new List<Transaction>
        {
            new() { Id = 1, Description = "Breakfast", Amount = 15.0, TransactionType = TransactionType.Expense , CategoryId = 1},
            new() { Id = 1, Description = "Lunch", Amount = 20.0, TransactionType = TransactionType.Expense , CategoryId = 1},
            new() { Id = 1, Description = "Dinner", Amount = 20.0, TransactionType = TransactionType.Expense , CategoryId = 1},
            new() { Id = 2, Description = "Grocery shopping", Amount = 50.0, TransactionType = TransactionType.Expense, CategoryId = 2},
            new() { Id = 3, Description = "Movie night", Amount = 15.0, TransactionType = TransactionType.Expense, CategoryId = 3 },
            new() { Id = 4, Description = "Salary", Amount = 2000.0, TransactionType = TransactionType.Income, CategoryId = 4 },
        };

        return transactions;
    }
}