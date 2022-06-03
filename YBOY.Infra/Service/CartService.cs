using System.Collections.Generic;
using YBOY.Core.Data;
using YBOY.Core.Repository;
using YBOY.Core.Service;

namespace YBOY.Infra.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        public CartService(ICartRepository _cartRepository)
        {
            cartRepository = _cartRepository;
        }

        public List<Cart> GetAllOrderInCart()
        {
            return cartRepository.GetAllOrderInCart();
        }

        public bool createCart(Cart cart)
        {
            return cartRepository.createCart(cart);
        }

        public bool deleteCart(int id)
        {
            return cartRepository.deleteCart(id);
        }
    }
}
