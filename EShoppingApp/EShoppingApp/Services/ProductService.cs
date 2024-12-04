using AutoMapper;
using EShoppingApp.Interfaces;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;

namespace EShoppingApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<int, Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<int, Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public async Task<bool> AddNewProduct(ProductDTO product)
        {
            var myProduct = _mapper.Map<Product>(product);
            myProduct = await _productRepository.Add(myProduct);
            return product != null;
        }
        
        public async Task<ICollection<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            return products.ToList();
        }
    }
}
