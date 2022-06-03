using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.DTO;

namespace YBOY.Core.Service
{
   public  interface IOrder_ProductService
    {
        public List<Order_Product> GetAllOrder_product();
        public bool CreateOrder_product(productList productList);
        public bool UpdateOrder_product(Order_Product order_Product);
        public bool DeleteOrder_product(int id);
        public bool UpdateOrder_product_count(List<OrderWithProductForUser> orderWithProductForUsers);
    }
}
