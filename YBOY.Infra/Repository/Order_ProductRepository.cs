using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YBOY.Core.Common;
using YBOY.Core.Data;
using YBOY.Core.DTO;
using YBOY.Core.Repository;


namespace YBOY.Infra.Repository
{
    public class Order_ProductRepository : IOrder_ProductRepository
    {
        private readonly IDbContext dbContext;
        //private  User_orderRepository user_OrderRepository1;
        public Order_ProductRepository(IDbContext _dbContext )
        {
            dbContext = _dbContext;
           
        }
        public List<Order_Product> GetAllOrder_product()
        {
            IEnumerable<Order_Product> result = dbContext.Connection.Query<Order_Product>("order_product_package.GetAllOrder_product", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateOrder_product(productList  productList)
        {
            User_orderRepository user_OrderRepository = new User_orderRepository(dbContext);
            User_order user_ = new User_order();
            user_.User_id = productList.User_id;

            float totalAmount = 0;
            for (int i = 0; i < productList.product_price.Count; i++)
            {
                totalAmount += productList.product_price[i];
            }

            user_.Total_amount = totalAmount;

            var order_id = user_OrderRepository.Createorder(user_);

            var p = new DynamicParameters();


            p.Add("order_id_", order_id.Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("pro_count", 1, dbType: DbType.Int32, direction: ParameterDirection.Input);

            for (int i = 0; i < productList.Product_id.Count; i++)
            {
                p.Add("product_id_", productList.Product_id[i], dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.Connection.ExecuteAsync("order_product_package.CreateOrder_product", p, commandType: CommandType.StoredProcedure);
            }

            return true;
        }
        public bool UpdateOrder_product(Order_Product order_Product)
        {

            var p = new DynamicParameters();
            p.Add("Order_product_id_", order_Product.Order_Product_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("order_id_", order_Product.Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("product_id_", order_Product.Product_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("order_product_package.UpdateOrder_product", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteOrder_product(int id)
        {
            var p = new DynamicParameters();
            p.Add("Order_product_id_", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("order_product_package.DeleteOrder_product", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateOrder_product_count(List<OrderWithProductForUser> orderWithProductForUsers)
        {
            var p = new DynamicParameters();

            for (int i = 0; i < orderWithProductForUsers.Count; i++)
            {

                p.Add("product_id_", orderWithProductForUsers[i].product_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("order_id_", orderWithProductForUsers[i].order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("count_", orderWithProductForUsers[i].product_count, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.Connection.ExecuteAsync("order_product_package.UpdateOrder_product_count", p, commandType: CommandType.StoredProcedure);
            }

            return true;
        }


        
    }
}
