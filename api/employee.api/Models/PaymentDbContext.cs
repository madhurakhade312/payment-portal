using Microsoft.EntityFrameworkCore;

namespace employee.api.Models;

public class PaymentDbContext : DbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }

    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasPrecision(18, 2);
        modelBuilder.Entity<Transaction>().Property(t => t.Status).HasConversion<string>().HasConversion<string>().HasMaxLength(20);
    }
}