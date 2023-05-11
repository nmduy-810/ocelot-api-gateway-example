using ProductAPI.Models;

namespace ProductAPI.Services;

public interface IProductService
{
    public Task<IEnumerable<Product>> GetProductListAsync();
    
    public Task<Product?> GetProductByIdAsync(int id);
    
    public Task<Product> AddProduct(Product product);
    
    public Task<Product> UpdateProduct(Product product);
    
    public Task<bool> DeleteProduct(int id);
}