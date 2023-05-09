using System;
using System.Linq;
using System.Collections.Generic;
using CEM.Models;
using CEM.Util;

namespace CEM.Views;

public interface ITableUI
{
    public void DrawTable();
}

public class ConsoleTableUI : ITableUI
{
    private readonly List<CategoryModel> _categoriesWithTransactions;

    public ConsoleTableUI(List<CategoryModel> categoriesWithTransactions)
    {
        _categoriesWithTransactions = categoriesWithTransactions;
    }

    public void DrawTable()
    {
        DrawHeader();
        DrawMainData();
        DrawFooterWithTotal();
    }

    private void DrawHeader()
    {
        Console.WriteLine("| {0,-40} | {1,15} | {2,15} |", "Tags/Categories of May 2023", "Earned", "Spent");
        Console.WriteLine("--------------------------------------------------------------------------------");
    }

    private void DrawMainData()
    {
        float income = 0;
        float expense = 0;

        foreach (var category in _categoriesWithTransactions)
        {
            foreach (var transaction in category.TransactionsInCategory)
            {
                income = 0;
                expense = 0;

                if (transaction.TransactionType == RequestType.Income)
                {
                    income += transaction.Amount;
                }
                else
                {
                    expense += transaction.Amount;
                }
            }

            Console.WriteLine("| {0,-40} | {1,15:C2} | {2,15:C2} |", category.Name, income, expense);
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }

    private void DrawFooterWithTotal()
    {
        float totalEarned = 0;
        float totalSpent = 0;

        foreach (var category in _categoriesWithTransactions)
        {
            List<float> incomes = category.TransactionsInCategory
                .Where(t => t.TransactionType == RequestType.Income)
                .Select(t => t.Amount)
                .ToList();

            List<float> expenses = category.TransactionsInCategory
                .Where(t => t.TransactionType == RequestType.Expense)
                .Select(t => t.Amount)
                .ToList();


            totalSpent += expenses.Sum();
            totalEarned += incomes.Sum();
        }

        Console.WriteLine("| {0,-40} | {1,15:C2} | {2,15:C2} |", "Total", totalEarned, totalSpent);
        Console.WriteLine("--------------------------------------------------------------------------------");
    }
}