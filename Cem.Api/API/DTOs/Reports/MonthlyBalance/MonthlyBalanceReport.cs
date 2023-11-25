namespace CemApi.DTOs.Reports.MonthlyBalance;

public class MonthlyBalanceReport
{
    public List<BalancePerCategory> MonthlyBalancesPerCategory { get; set; }
    public double TotalEarned { get; set; }
    public double TotalSpent { get; set; }
    public DateTime Date {get; set; }

    public int Year => Date.Year;
    public int Month => Date.Month;
}