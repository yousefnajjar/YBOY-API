using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Repository
{
    public interface ICartRepository
    {

        public List<Cart> GetAllOrderInCart();

        public bool createCart(Cart cart);

        public bool deleteCart(int id);
    }
}
