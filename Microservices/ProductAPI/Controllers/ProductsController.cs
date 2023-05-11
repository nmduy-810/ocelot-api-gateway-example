using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductListAsync() => Ok(await _productService.GetProductListAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id) => Ok(await _productService.GetProductByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product) => Ok(await _productService.AddProduct(product));

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(Product product) => Ok(await _productService.UpdateProduct(product));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id) => Ok(await _productService.DeleteProduct(id));
}