using CEM.Util;
using CemApi.DTOs;
using CemApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CemApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] TransactionDTO transactionDto)
    {
        _transactionService.MakeTransaction(transactionDto);
        return Ok();
    }
}
