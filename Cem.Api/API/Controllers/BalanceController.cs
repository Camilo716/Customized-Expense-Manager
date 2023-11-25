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
        var balanceReportCreationDTO = new BalanceReportCreationDTO
        {
            Date = _dateManager.GetCurrentDate()
        };

        return await _balanceService.GenerateMonthlyBalanceReport(balanceReportCreationDTO);
    }
}
