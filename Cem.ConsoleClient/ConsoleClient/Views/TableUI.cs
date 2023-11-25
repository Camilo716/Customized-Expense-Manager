using System;
using CemApi.DTOs.Reports.MonthlyBalance;

namespace CEM.Views;


public class ConsoleTableUI
{
    public static void DrawMonthlyBalanceReport(MonthlyBalanceReport report)
    {
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("| {0,-40} | {1,15} | {2,15} |", $"Tags/Categories of {report.Date:MMMM yyyy}", "Earned", "Spent");
        Console.WriteLine("--------------------------------------------------------------------------------");

        foreach (var balancePerCategory in report.MonthlyBalancesPerCategory)
        {
            DrawCategoryRow(balancePerCategory.Category, balancePerCategory.Earned, balancePerCategory.Spent);
        }

        Console.ForegroundColor = ConsoleColor.Red;
        DrawTotalRow(report.TotalEarned, report.TotalSpent);
    }

    private static void DrawCategoryRow(string category, double earned, double spent)
    {
        Console.WriteLine("| {0,-40} | {1,15:C2} | {2,15:C2} |", category, earned.ToString("C"), spent.ToString("C"));
        Console.WriteLine("--------------------------------------------------------------------------------");
    }

    private static void DrawTotalRow(double totalEarned, double totalSpent)
    {
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("| {0,-40} | {1,15:C2} | {2,15:C2} |", "Total", totalEarned, totalSpent);
        Console.WriteLine("--------------------------------------------------------------------------------");
    }
}