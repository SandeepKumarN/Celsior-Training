using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;

namespace EShoppingApp.Interfaces
{
    public interface IProductService
    {
        public Task<bool> AddNewProduct(ProductDTO product);
        public Task<ICollection<Product>> GetAllProducts();
    }
}
