using AspCoreMongoSample.Entities;
using AspCoreMongoSample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreMongoSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository productRepository;

    public ProductController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await productRepository.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(string id)
    {
        var products = await productRepository.GetByIdAsync(id);
        if (products == null)
        {
            return NotFound();
        }
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await productRepository.CreateAsync(product);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(string id, Product updatedProduct)
    {
        var queriedProduct = await productRepository.GetByIdAsync(id);
        if (queriedProduct == null)
        {
            return NotFound();
        }
        await productRepository.UpdateAsync(id, updatedProduct);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var product = await productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        await productRepository.DeleteAsync(id);
        return NoContent();
    }
}