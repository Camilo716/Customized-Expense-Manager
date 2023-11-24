namespace CemApi.DTOs.Reports.MonthlyBalance;
public class BalancePerCategory
{
    public string Category { get; set; }
    public double Earned { get; set; }
    public double Spent { get; set; }
}