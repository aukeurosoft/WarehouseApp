//namespace WarehouseApp.Services
//{
using Microsoft.EntityFrameworkCore;
using WarehouseApp.Data;

public class TransactionService
{
    private readonly AppDbContext _context;

    public TransactionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transaction>> GetAllTransactionsAsync()
    {
        return await _context.Transactions.Include(t => t.Product).OrderByDescending(t => t.Date).ToListAsync();
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
    }
}
//}
