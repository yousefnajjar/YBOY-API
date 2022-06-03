using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Service
{
    public interface ICartService
    {

        public List<Cart> GetAllOrderInCart();

        public bool createCart(Cart cart);

        public bool deleteCart(int id); 
    }
}
