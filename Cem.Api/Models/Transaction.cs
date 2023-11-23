using Cem.Api.Common;

namespace Cem.Api.Models;

public class Transaction
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public double Amount { get; set; }

    public TransactionType TransactionType { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}