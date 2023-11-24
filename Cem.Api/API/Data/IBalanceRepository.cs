using CemApi.DTOs.Reports.MonthlyBalance;

namespace CemApi.Data;

public interface IBalanceRepository
{
    Task<MonthlyBalanceReport> GetMonthlyBalanceReport();
}