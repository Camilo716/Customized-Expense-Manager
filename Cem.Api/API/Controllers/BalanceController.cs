namespace CemApi.Controllers;

using Cem.Api.DateManagement;
using CemApi.DTOs.Reports.MonthlyBalance;
using CemApi.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BalanceController : ControllerBase
{
    private readonly BalanceService _balanceService;
    private readonly IDateManager _dateManager;

    public BalanceController(BalanceService balanceService, IDateManager dateManager)
    {
        _balanceService = balanceService;
        _dateManager = dateManager;
    }

    [HttpGet]
    [Route("MonthlyBalanceReport")]
    public async Task<ActionResult<MonthlyBalanceReport>> GetMonthlyBalanceReport()
    {
        DateTime date = _dateManager.GetCurrentDate();
        var monthlyBalanceReport = new MonthlyBalanceReport
        {
            Date = new DateOnly(date.Year, date.Month, 1)
        };

        return await _balanceService.GenerateMonthlyBalanceReport(monthlyBalanceReport);
    }
}
