using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YBOY.Core.Data;
using YBOY.Core.Service;

namespace YBOY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService _cartService)
        {
            cartService = _cartService;
        }
        [HttpGet]
        [Route("GetAllOrderInCart")]
        public List<Cart> GetAllOrderInCart()
        {
            return cartService.GetAllOrderInCart();
        }
        [HttpPost]
        [Route("createCart")]
        public bool createCart(Cart cart)
        {
            return cartService.createCart(cart);
        }
        [HttpDelete]
        [Route("deleteCart/{id}")]
        public bool deleteCart(int id)
        {
            return cartService.deleteCart(id);
        }
    }
}
