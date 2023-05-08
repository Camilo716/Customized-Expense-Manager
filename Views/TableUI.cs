using System;
using System.Linq;

namespace CEM.Views;

public interface ITableUI
{
    public void DrawTable(string[] categories, float[] earned, float[] spent);
}

public class ConsoleTableUI : ITableUI
{

    public void DrawTable(string[] categories, float[] earned, float[] spent)
    {
        DrawHeader();
        DrawMainData(categories, earned, spent);
        DrawFooterWithTotal(earned, spent);
    }

    private void DrawHeader()
    {
        Console.WriteLine("| {0,-40} | {1,10} | {2,10} |", "Tags/Categories of May 2023", "Earned", "Spent");
        Console.WriteLine("--------------------------------------------------------------------------------");
    }

    private void DrawMainData(string[] categories, float[] earned, float[] spent)
    {
        for (int i = 0; i < categories.Length; i++)
        {
            Console.WriteLine("| {0,-40} | {1,10:C2} | {2,10:C2} |", categories[i], earned[i], spent[i]);
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }

    private void DrawFooterWithTotal(float[] earned, float[] spent)
    {
        float totalEarned = earned.Sum();
        float totalSpent = spent.Sum();
        Console.WriteLine("| {0,-40} | {1,10:C2} | {2,10:C2} |", "Total", totalEarned, totalSpent);
        Console.WriteLine("--------------------------------------------------------------------------------");
    }
}