using System;
using System.Linq;
using System.Collections.Generic;
using CemApi.Util;
using CemApi.Models;

namespace CEM.Views;

public interface ITableUI
{
    public void DrawTable();
}

public class ConsoleTableUI : ITableUI
{
    private readonly List<Category> _categoriesWithTransactions;

    public ConsoleTableUI(List<Category> categoriesWithTransactions)
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
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("| {0,-40} | {1,15} | {2,15} |", "Tags/Categories of May 2023", "Earned", "Spent");
        Console.WriteLine("--------------------------------------------------------------------------------");
    }

    private void DrawMainData()
    {
        double income = 0;
        double expense = 0;

        foreach (var category in _categoriesWithTransactions)
        {
            foreach (var transaction in category.Transactions)
            {

                if (transaction.TransactionType == TransactionType.Income)
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
            income = 0;
            expense = 0;
        }
    }

    private void DrawFooterWithTotal()
    {
        double totalEarned = 0;
        double totalSpent = 0;

        foreach (var category in _categoriesWithTransactions)
        {
            List<double> incomes = category.Transactions
                .Where(t => t.TransactionType == TransactionType.Income)
                .Select(t => t.Amount)
                .ToList();

            List<double> expenses = category.Transactions
                .Where(t => t.TransactionType == TransactionType.Expense)
                .Select(t => t.Amount)
                .ToList();

            totalSpent += expenses.Sum();
            totalEarned += incomes.Sum();
        }

        Console.WriteLine("| {0,-40} | {1,15:C2} | {2,15:C2} |", "Total", totalEarned, totalSpent);
        Console.WriteLine("--------------------------------------------------------------------------------");
    }
}