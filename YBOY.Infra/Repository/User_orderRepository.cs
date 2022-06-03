using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YBOY.Core.Common;
using YBOY.Core.Data;
using YBOY.Core.DTO;
using YBOY.Core.Repository;
using YBOY.Core.Service;
using YBOY.Infra.Service;

namespace YBOY.Infra.Repository
{
    public class User_orderRepository : IUser_orderRepository
    {
        private readonly IDbContext dbContext;

        

        public User_orderRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
            

        }
        public List<User_order> GetAllorder()
        {
            IEnumerable<User_order> result = dbContext.Connection.Query<User_order>("user_orderrrrr_Package.GetAllorder", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        
        public List<OrderWithUserInfo> GetAllDeliveredorderWithUserInfo()
        {
            IEnumerable<OrderWithUserInfo> result = dbContext.Connection.Query<OrderWithUserInfo>("user_orderrrrr_Package.GetAllDeliveredorderWithUserInfo", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<OrderWithUserInfo> GetAllPendingorderWithUserInfo()
        {
            IEnumerable<OrderWithUserInfo> result = dbContext.Connection.Query<OrderWithUserInfo>("user_orderrrrr_Package.GetAllPendingorderWithUserInfo", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<OrderWithProduct> GetAllOrderWithproduct(OrderWithProduct orderWithProduct)
        {
            var p = new DynamicParameters();
            p.Add("order_id_", orderWithProduct.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<OrderWithProduct> result = dbContext.Connection.Query<OrderWithProduct>("user_orderrrrr_Package.GetAllOrderWithproduct", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public OrderId Createorder(User_order user)
        {
            var p = new DynamicParameters();
            p.Add("order_date_", DateTime.Now, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("quntity_", 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("total_amount_", user.Total_amount, dbType: DbType.Double, direction: ParameterDirection.Input);
          
            p.Add("user_id_", user.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<OrderId> result = dbContext.Connection.Query<OrderId>("user_orderrrrr_Package.Createorder", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool Updateorder(User_order user)
        {
            //var p = new DynamicParameters();
            //p.Add("order_id_", user.Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //p.Add("order_date_", user.Order_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            //p.Add("quntity_", user.Quntity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //p.Add("total_amount_", user.Total_amount, dbType: DbType.Double, direction: ParameterDirection.Input);
            //p.Add("status_", user.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            //p.Add("user_id_", user.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            //var result = dbContext.Connection.ExecuteAsync("user_order_Package.Updateorder", p, commandType: CommandType.StoredProcedure);

            return true;
            
        }

        public bool Deleteorder(int id)
        {
            var p = new DynamicParameters();
            p.Add("order_id_", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("user_orderrrrr_Package.Deleteorder", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool StatusUpdate(statusUpdate statusUpdate)
        {
            var p = new DynamicParameters();
            

            if(statusUpdate.status=="Accept")
            {
                for (int i = 0; i < statusUpdate.orderWithUserInfos.Count; i++)
                {
                    if(statusUpdate.orderWithUserInfos[i].user_id == statusUpdate.user_id)
                    {
                        p.Add("order_id_", statusUpdate.orderWithUserInfos[i].Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        var result = dbContext.Connection.ExecuteAsync("user_orderrrrr_Package.StatusAccept", p, commandType: CommandType.StoredProcedure);
                    }
                }
                
            } 
            else if(statusUpdate.status == "Ready For Delivered")
            {

                for (int i = 0; i < statusUpdate.orderWithUserInfos.Count; i++)
                {
                    if (statusUpdate.orderWithUserInfos[i].user_id == statusUpdate.user_id)
                    {
                        p.Add("order_id_", statusUpdate.orderWithUserInfos[i].Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        var result = dbContext.Connection.ExecuteAsync("user_orderrrrr_Package.StatusDone", p, commandType: CommandType.StoredProcedure);
                    }
                }

               
            }
            else if (statusUpdate.status == "Delivered")
            {
                for (int i = 0; i < statusUpdate.orderWithUserInfos.Count; i++)
                {
                    if (statusUpdate.orderWithUserInfos[i].user_id == statusUpdate.user_id)
                    {
                        p.Add("order_id_", statusUpdate.orderWithUserInfos[i].Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        var result = dbContext.Connection.ExecuteAsync("user_orderrrrr_Package.StatusDelivered", p, commandType: CommandType.StoredProcedure);
                    }
                }

               
             
            }

            return true;
        }

        public List<OrderWithUserInfo> GetAllAcceptedorder()
        {
            IEnumerable<OrderWithUserInfo> result = dbContext.Connection.Query<OrderWithUserInfo>("user_orderrrrr_Package.GetAllAcceptedorder", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<OrderWithUserInfo> GetAllReadyForDeliveredorder()
        {
            IEnumerable<OrderWithUserInfo> result = dbContext.Connection.Query<OrderWithUserInfo>("user_orderrrrr_Package.GetAllReadyForDeliveredorder", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<OrderWithUserInfo> GetAllDeliverdOrderForDriver(User_order user)
        {
            var p = new DynamicParameters();
            p.Add("driver_id", user.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<OrderWithUserInfo> result =
                dbContext.Connection.Query<OrderWithUserInfo>("user_orderrrrr_Package.GetAllDeliverdOrderForDriver", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<OrderWithProductForUser> GetAllProductForUser(User_order user)
        {
            var p = new DynamicParameters();
            p.Add("user_id_", user.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<OrderWithProductForUser> result = 
                dbContext.Connection.Query<OrderWithProductForUser>("user_orderrrrr_Package.GetAllProductForUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<OrderWithUserInfo> GetAllAcceptedOrderFromDriver(User_order user)
        {
            var p = new DynamicParameters();
            p.Add("driver_id", user.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<OrderWithUserInfo> result =
                dbContext.Connection.Query<OrderWithUserInfo>("user_orderrrrr_Package.GetAllAcceptedOrderFromDriver", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<OrderId> GetAllOrderForUser(User_order user)
        {
            var p = new DynamicParameters();
            p.Add("user_id_", user.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<OrderId> result =
                dbContext.Connection.Query<OrderId>("user_orderrrrr_Package.GetAllOrderForUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<OrderId> GetAllOrderReadyForUser(User_order user)
        {
            var p = new DynamicParameters();
            p.Add("user_id_", user.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<OrderId> result =
                dbContext.Connection.Query<OrderId>("user_orderrrrr_Package.GetAllOrderReadyForUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateDriver_order(userAndDriverId userAndDriverId)
        {
            List<OrderId> orderId = new List<OrderId>();
            User_order user = new User_order();
            user.User_id = userAndDriverId.user_id;
            orderId = GetAllOrderReadyForUser(user);

            var p = new DynamicParameters();

            p.Add("driver_id", userAndDriverId.driver_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            for (int i = 0; i < orderId.Count; i++)
            {

                p.Add("order_id_", orderId[i].Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result =
                    dbContext.Connection.ExecuteAsync("driver_order_package.CreateDriver_order", p, commandType: CommandType.StoredProcedure);

            }

            return true;
        }

        public bool UpdateOrder_quntityAndTotal_amount(List<OrderId> orderIds)
        {

            List<OrderId> LastUpdateTotal_amount = new List<OrderId>();
            User_order user = new User_order();
            user.User_id = orderIds[0].User_id;
            LastUpdateTotal_amount = GetAllOrderForUser(user);

           var p = new DynamicParameters();
            for (int i = 0; i < orderIds.Count; i++)
            {
                p.Add("order_id_", orderIds[i].Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                orderIds[i].total_amount = orderIds[i].Quntity * LastUpdateTotal_amount[i].total_amount;
                p.Add("quntity_", orderIds[i].Quntity, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("total_amount_", orderIds[i].total_amount, dbType: DbType.Double, direction: ParameterDirection.Input);
                var result = dbContext.Connection.ExecuteAsync("user_orderrrrr_Package.UpdateOrder_quntityAndTotal_amount", p, commandType: CommandType.StoredProcedure);
            }
            

            return true;
        }


        public bool UpdateOrder_Total_amount(updateTotalAmountDependeOnMeal updateTotalAmountDependeOnMeals)
        {
            var p = new DynamicParameters();

            
           
                float total_amount = 0;
                for (int i = 0; i < updateTotalAmountDependeOnMeals.Quntity; i++)
                {
                    for (int ii = 0; ii < updateTotalAmountDependeOnMeals.orderWithProductForUsers.Count; ii++)
                    {
                        if (updateTotalAmountDependeOnMeals.order_id
                            == updateTotalAmountDependeOnMeals.orderWithProductForUsers[ii].order_id)
                        {
                            total_amount +=
                                 updateTotalAmountDependeOnMeals.orderWithProductForUsers[ii].product_count *
                                  updateTotalAmountDependeOnMeals.orderWithProductForUsers[ii].product_price;
                        }

                    }
                }
            p.Add("quntity_", updateTotalAmountDependeOnMeals.Quntity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("order_id_", updateTotalAmountDependeOnMeals.order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("total_amount_", total_amount, dbType: DbType.Double, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("user_orderrrrr_Package.Updateorder", p, commandType: CommandType.StoredProcedure);


            return true;
        }

        public bool Plus_(OrderWithProductForUser orderWithProductForUser)
        {
            var p = new DynamicParameters();

            p.Add("order_id_", orderWithProductForUser.order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            for (int i = 0; i < orderWithProductForUser.Quntity; i++)
            {
                p.Add("price_", orderWithProductForUser.product_price, dbType: DbType.Double, direction: ParameterDirection.Input);
                var result = dbContext.Connection.ExecuteAsync("user_orderrrrr_Package.Plus_", p, commandType: CommandType.StoredProcedure);
            }

            return true;
        }
        public bool Minus_(OrderWithProductForUser orderWithProductForUser)
        {
            var p = new DynamicParameters();
            p.Add("order_id_", orderWithProductForUser.order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            for (int i = 0; i < orderWithProductForUser.Quntity; i++)
            {
                p.Add("price_", orderWithProductForUser.product_price, dbType: DbType.Double, direction: ParameterDirection.Input);
                var result = dbContext.Connection.ExecuteAsync("user_orderrrrr_Package.Minus_", p, commandType: CommandType.StoredProcedure);
            }
            
            return true;
        }


        public bool statusPendingAndPaymentOnline(List<OrderId> orderIds)
        {
            var p = new DynamicParameters();
            

            for (int i = 0; i < orderIds.Count; i++)
            {
                p.Add("order_id_", orderIds[i].Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.Connection.ExecuteAsync("user_orderrrrr_Package.statusPendingAndPaymentOnline", p, commandType: CommandType.StoredProcedure);
            }

             
            return true;
        }

        public bool statusPendingAndPaymentCash(List<OrderId> orderIds)
        {
            var p = new DynamicParameters();


            for (int i = 0; i < orderIds.Count; i++)
            {
                p.Add("order_id_", orderIds[i].Order_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.Connection.ExecuteAsync("user_orderrrrr_Package.statusPendingAndPaymentCash", p, commandType: CommandType.StoredProcedure);
            }


            return true;
        }
    }
}
