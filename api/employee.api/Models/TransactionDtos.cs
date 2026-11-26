using System.ComponentModel.DataAnnotations;

namespace employee.api.Models;

public class CreateTransactionDto
{
    [Required, MaxLength(100)]
    public string MerchantName { get; set; } = string.Empty;

    [Range(0.01, 1000000)]
    public decimal Amount { get; set; }
}

public class UpdateTransactionDto
{
    [Required, MaxLength(100)]
    public string MerchantName { get; set; } = string.Empty;

    [Range(0.01, 1000000)]
    public decimal Amount { get; set; }

    public TransactionStatus Status { get; set; }
}

public class TransactionDto
{
    public int TransactionId { get; set; }
    public string MerchantName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
}