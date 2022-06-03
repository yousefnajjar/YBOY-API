using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YBOY.Core.Common;
using YBOY.Core.Data;
using YBOY.Core.Repository;

namespace YBOY.Infra.Repository
{
    public class CartRepository : ICartRepository
    {

        private readonly IDbContext dbContext;

        public CartRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public List<Cart> GetAllOrderInCart()
        {
            IEnumerable<Cart> result = dbContext.Connection.Query<Cart>("cart_package.GetAllOrderInCart", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public bool createCart(Cart cart)
        {
            var p = new DynamicParameters();
            p.Add("order_id_", cart.Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_id_", cart.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("cart_package.createCart", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool deleteCart(int id)
        {
            var p = new DynamicParameters();
            p.Add("cart_id_", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("cart_package.deleteCart", p, commandType: CommandType.StoredProcedure);

            return true;
        }

    }
}
