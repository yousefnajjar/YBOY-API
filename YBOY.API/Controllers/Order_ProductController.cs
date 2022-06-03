using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YBOY.Core.Data;
using YBOY.Core.DTO;
using YBOY.Core.Service;

namespace YBOY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_ProductController : ControllerBase
    {
        private readonly IOrder_ProductService order_ProductService;

        public Order_ProductController(IOrder_ProductService _order_ProductService)
        {
            order_ProductService = _order_ProductService;
        }
        [HttpGet]
        [Route("GetAllOrder_product")]
        public List<Order_Product> GetAllOrder_product()
        {
            return order_ProductService.GetAllOrder_product();
        }
        [HttpPost]
        [Route("CreateOrder_product")]
        public bool CreateOrder_product(productList productList)
        {
            return order_ProductService.CreateOrder_product(productList);
        }
        [HttpPut]
        [Route("UpdateOrder_product")]
        public bool UpdateOrder_product(Order_Product order_Product)
        {
            return order_ProductService.UpdateOrder_product(order_Product);
        }
        [HttpDelete]
        [Route("DeleteOrder_product/{id}")]
        public bool DeleteOrder_product(int id)
        {
            return order_ProductService.DeleteOrder_product(id);
        }

        [HttpPut]
        [Route("UpdateOrder_product_count")]
        public bool UpdateOrder_product_count(List<OrderWithProductForUser> orderWithProductForUsers)
        {
            return order_ProductService.UpdateOrder_product_count(orderWithProductForUsers);
        }
    }
}
