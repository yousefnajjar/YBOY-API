using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.DTO;

namespace YBOY.Core.Repository
{
    public interface IUser_orderRepository
    {
        public List<User_order> GetAllorder();
        
        public List<OrderWithUserInfo> GetAllDeliveredorderWithUserInfo();
        public List<OrderWithUserInfo> GetAllPendingorderWithUserInfo();
        public List<OrderWithProduct> GetAllOrderWithproduct(OrderWithProduct orderWithProduct);
        public OrderId Createorder(User_order user);
        public bool Updateorder(User_order user);
        public bool Deleteorder(int id);
        public bool StatusUpdate(statusUpdate statusUpdate);

        public List<OrderWithUserInfo> GetAllAcceptedorder();
        public List<OrderWithUserInfo> GetAllReadyForDeliveredorder();
        public List<OrderWithProductForUser> GetAllProductForUser(User_order user);
        public List<OrderId> GetAllOrderForUser(User_order user);
        public bool statusPendingAndPaymentOnline(List<OrderId> orderIds);
        public bool statusPendingAndPaymentCash(List<OrderId> orderIds);
        public bool UpdateOrder_quntityAndTotal_amount(List<OrderId> orderIds);
        public bool Plus_(OrderWithProductForUser orderWithProductForUser);
        public bool Minus_(OrderWithProductForUser orderWithProductForUser);
        public bool UpdateOrder_Total_amount(updateTotalAmountDependeOnMeal updateTotalAmountDependeOnMeals);
        public List<OrderId> GetAllOrderReadyForUser(User_order user);
        public bool CreateDriver_order(userAndDriverId userAndDriverId);
        public List<OrderWithUserInfo> GetAllAcceptedOrderFromDriver(User_order user);
        public List<OrderWithUserInfo> GetAllDeliverdOrderForDriver(User_order user);



    }
}
