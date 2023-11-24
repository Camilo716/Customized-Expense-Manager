namespace CemApi.Controllers;

using CemApi.DTOs.Reports.MonthlyBalance;
using CemApi.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BalanceController : ControllerBase
{
    private readonly BalanceService _balanceService;

    public BalanceController(BalanceService balanceService)
    {
        _balanceService = balanceService;
    }

    [HttpGet]
    [Route("MonthlyBalanceReport")]
    public async Task<ActionResult<MonthlyBalanceReport>> GetMonthlyBalanceReport()
    {
        return await _balanceService.GenerateMonthlyBalanceReport();
    }
}
