using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employee.api.Models;

public class Transaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TransactionId { get; set; }

    [Required, MaxLength(100)]
    public string MerchantName { get; set; } = string.Empty;

    [Range(0.01, 1000000)]
    public decimal Amount { get; set; }

    [Required, MaxLength(20)]
    public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}