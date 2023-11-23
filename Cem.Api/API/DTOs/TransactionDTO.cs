using CemApi.Util;

namespace CemApi.DTOs;

public class TransactionDTO
{
    public string Category { get; set; }
    public string Description { get; set; }
    public string Amount { get; set; }
    public TransactionType RequestType { get; set; }
}