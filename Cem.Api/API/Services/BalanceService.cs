using CemApi.Data;
using CemApi.DTOs.Reports.MonthlyBalance;

namespace CemApi.Services;

public class BalanceService
{
    private readonly IBalanceRepository _balanceRepository;

    public BalanceService(IBalanceRepository balanceRepository)
    {
        _balanceRepository = balanceRepository;
    }

    public async Task<MonthlyBalanceReport> GenerateMonthlyBalanceReport()
    {
        return await _balanceRepository.GetMonthlyBalanceReport();
    }
}