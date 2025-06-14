//namespace WarehouseApp.Services
//{
using Microsoft.EntityFrameworkCore;
using WarehouseApp.Data;

public class ProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task AddProductAsync(Product product)
    {
        if (product.Name != null)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateProductQuantityAsync(int productId, int changeAmount)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product != null)
        {
            product.Quantity += changeAmount;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException($"Товар з ID {productId} не знайдено.");
        }
    }

    public async Task UpdateProductPriceAsync(int productId, double changePrice)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product != null)
        {
            product.Price += changePrice;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException($"Товар з ID {productId} не знайдено.");
        }
    }

}
//}
