using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.DTO;
using YBOY.Core.Repository;
using YBOY.Core.Service;

namespace YBOY.Infra.Service
{
   public  class Order_ProductService : IOrder_ProductService
    {
        private readonly IOrder_ProductRepository order_ProductRepository;

        public Order_ProductService(IOrder_ProductRepository _order_ProductRepository)
        {
         order_ProductRepository = _order_ProductRepository;
        }
        public List<Order_Product> GetAllOrder_product()
        {
            return order_ProductRepository.GetAllOrder_product();
        }
        public bool CreateOrder_product(productList productList)
        {
            return order_ProductRepository.CreateOrder_product(productList);
        }
        public bool UpdateOrder_product(Order_Product order_Product)
        {
            return order_ProductRepository.UpdateOrder_product(order_Product);
        }
        public bool DeleteOrder_product(int id)
        {
            return order_ProductRepository.DeleteOrder_product(id);
        }
        public bool UpdateOrder_product_count(List<OrderWithProductForUser> orderWithProductForUsers)
        {
            return order_ProductRepository.UpdateOrder_product_count(orderWithProductForUsers);
        }
    }
}
