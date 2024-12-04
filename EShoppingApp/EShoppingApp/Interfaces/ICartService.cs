using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;

namespace EShoppingApp.Interfaces
{
    public interface ICartService
    {
        Task<int> Add(CartDTO cart);
        Task<Cart> Get(int cartId);
        Task<bool> Delete(int cartId);
    }
}
