using AutoMapper;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Repositories;

namespace EShoppingApp.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<int, Cart> _cartRepository;
        private readonly IMapper _mapper;

        public CartService(IRepository<int, Cart> cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<int> Add(CartDTO cart)
        {
            var carts = _mapper.Map<Cart>(cart);

            var addedCart = await _cartRepository.Add(carts);


            return addedCart.Id;
        }

        public async Task<bool> Delete(int cartId)
        {
            var deletedCart = await _cartRepository.Delete(cartId);

            return deletedCart != null;
        }

        public async Task<Cart> Get(int Id)
        {
            var cart = await _cartRepository.Get(Id);
            return cart;
        }

        
    }
}
