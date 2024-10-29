using EFAPIProj.Interfaces;
using EFAPIProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFAPIProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IRepository<int, ProductImage> _productImageRepository;

        public ProductImageController(IRepository<int, ProductImage> productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        // Add new product image
        [HttpPost]
        public async Task<IActionResult> AddProductImage(ProductImage productImage)
        {
            if (productImage == null)
                return BadRequest();

            var addedProductImage = await _productImageRepository.Add(productImage);
            return CreatedAtAction(nameof(GetProductImageById), new { id = addedProductImage.Id }, addedProductImage);
        }

        // Get product image by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(int id)
        {
            var productImage = await _productImageRepository.Get(id);
            if (productImage == null)
                return NotFound();

            return Ok(productImage);
        }
    }
}
