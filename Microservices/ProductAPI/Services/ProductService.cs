using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Services;

public class ProductService : IProductService
{
    private readonly ProductDbContext _context;

    public ProductService(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProductListAsync() => await _context.Products.ToListAsync();

    public async Task<Product?> GetProductByIdAsync(int id) => await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
    
    public async Task<Product> AddProduct(Product product)
    {
        var result = await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        var result = _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var filteredData = await _context.Products.FindAsync(id);
        if (filteredData == null) 
            return false;
        
        _context.Remove(filteredData);
        await _context.SaveChangesAsync();
        return true;
    }
}