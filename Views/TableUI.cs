using System;
namespace CEM.Views;

public interface ITableUI
{
    public string drawTable(string[,] tableGenerated);
}

public class ConsoleTableUI : ITableUI
{
    public string drawTable(string[,] tableGenerated)
    {
        return "";
    }


}