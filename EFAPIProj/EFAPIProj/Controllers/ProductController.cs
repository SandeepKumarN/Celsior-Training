using EFAPIProj.Interfaces;
using EFAPIProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFAPIProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<int, Product> _productRepository;

        public ProductController(IRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }

        // Get all products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        // Get product by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepository.Get(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // Add a new product
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product == null)
                return BadRequest();

            var addedProduct = await _productRepository.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = addedProduct.Id }, addedProduct);
        }

        // Update product price
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductPrice(int id, Product product)
        {
            if (product == null || id != product.Id)
                return BadRequest();

            var updatedProduct = await _productRepository.Update(id, product);
            return Ok(updatedProduct);
        }
    }
}
