using employee.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employee.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly PaymentDbContext _context;

    public TransactionsController(PaymentDbContext context)
    {
        _context = context;
    }
    private static TransactionDto ToDto(Transaction t) => new()
    {
        TransactionId = t.TransactionId,
        MerchantName = t.MerchantName,
        Amount = t.Amount,
        Status = t.Status,
        CreatedDate = t.CreatedDate
    };

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAll()
        => await _context.Transactions.AsNoTracking()
            .OrderByDescending(t => t.CreatedDate)
            .Select(t => new TransactionDto
            {
                TransactionId = t.TransactionId,
                MerchantName = t.MerchantName,
                Amount = t.Amount,
                Status = t.Status,
                CreatedDate = t.CreatedDate
            })
            .ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<TransactionDto>> GetById(int id)
    {
        var item = await _context.Transactions.AsNoTracking()
            .FirstOrDefaultAsync(t => t.TransactionId == id);
        return item is null ? NotFound() : ToDto(item);
    }

    [HttpPost]
    public async Task<ActionResult<TransactionDto>> Create(CreateTransactionDto input)
    {
        var entity = new Transaction
        {
            MerchantName = input.MerchantName,
            Amount = input.Amount
        };
        _context.Transactions.Add(entity);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entity.TransactionId }, ToDto(entity));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTransactionDto input)
    {
        var existing = await _context.Transactions.FindAsync(id);
        if (existing is null) return NotFound();
        existing.MerchantName = input.MerchantName;
        existing.Amount = input.Amount;
        existing.Status = input.Status;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _context.Transactions.FindAsync(id);
        if (existing is null) return NotFound();
        _context.Transactions.Remove(existing);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}