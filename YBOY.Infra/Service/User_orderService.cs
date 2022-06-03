using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.DTO;
using YBOY.Core.Repository;
using YBOY.Core.Service;

namespace YBOY.Infra.Service
{
    public class User_orderService : IUser_orderService
    {
        private readonly IUser_orderRepository user_OrderRepository;
        public User_orderService(IUser_orderRepository _user_OrderRepository)
        {
            user_OrderRepository = _user_OrderRepository;
        }
        public OrderId Createorder(User_order user)
        {
            return user_OrderRepository.Createorder(user);
        }

        public bool Deleteorder(int id)
        {
            return user_OrderRepository.Deleteorder(id);
        }

        public List<User_order> GetAllorder()
        {
            return user_OrderRepository.GetAllorder();
        }

        public List<OrderWithUserInfo> GetAllDeliveredorderWithUserInfo()
        {
            return user_OrderRepository.GetAllDeliveredorderWithUserInfo();
        }

        public List<OrderWithUserInfo> GetAllPendingorderWithUserInfo()
        {
            return user_OrderRepository.GetAllPendingorderWithUserInfo();
        }
        public List<OrderWithProduct> GetAllOrderWithproduct(OrderWithProduct orderWithProduct)
        {
            return user_OrderRepository.GetAllOrderWithproduct(orderWithProduct);
        }

        public bool Updateorder(User_order user)
        {
         return user_OrderRepository.Updateorder(user);
        }
        public bool StatusUpdate(statusUpdate statusUpdate)
        {
            return user_OrderRepository.StatusUpdate(statusUpdate);
        }

        public List<OrderWithUserInfo> GetAllAcceptedorder()
        {
            return user_OrderRepository.GetAllAcceptedorder();
        }
        public List<OrderWithUserInfo> GetAllReadyForDeliveredorder()
        {
            return user_OrderRepository.GetAllReadyForDeliveredorder();
        }
        public List<OrderWithProductForUser> GetAllProductForUser(User_order user)
        {
            return user_OrderRepository.GetAllProductForUser(user);
        }
        public List<OrderId> GetAllOrderForUser(User_order user)
        {
            return user_OrderRepository.GetAllOrderForUser(user);
        }
        public bool UpdateOrder_quntityAndTotal_amount(List<OrderId> orderIds)
        {
            return user_OrderRepository.UpdateOrder_quntityAndTotal_amount(orderIds);
        }
        public bool Plus_(OrderWithProductForUser orderWithProductForUser)
        {
            return user_OrderRepository.Plus_(orderWithProductForUser);
        }
        public bool Minus_(OrderWithProductForUser orderWithProductForUser)
        {
            return user_OrderRepository.Minus_(orderWithProductForUser);
        }
        public bool UpdateOrder_Total_amount(updateTotalAmountDependeOnMeal updateTotalAmountDependeOnMeals)
        {
            return user_OrderRepository.UpdateOrder_Total_amount(updateTotalAmountDependeOnMeals);
        }
        public bool statusPendingAndPaymentOnline(List<OrderId> orderIds)
        {
            return user_OrderRepository.statusPendingAndPaymentOnline(orderIds);
        }
        public bool statusPendingAndPaymentCash(List<OrderId> orderIds)
        {
            return user_OrderRepository.statusPendingAndPaymentCash(orderIds);
        }
        public List<OrderId> GetAllOrderReadyForUser(User_order user)
        {
            return user_OrderRepository.GetAllOrderReadyForUser(user);
        }
        public bool CreateDriver_order(userAndDriverId userAndDriverId)
        {
            return user_OrderRepository.CreateDriver_order(userAndDriverId);
        }
        public List<OrderWithUserInfo> GetAllAcceptedOrderFromDriver(User_order user)
        {
            return user_OrderRepository.GetAllAcceptedOrderFromDriver(user);
        }
        public List<OrderWithUserInfo> GetAllDeliverdOrderForDriver(User_order user)
        {
            return user_OrderRepository.GetAllDeliverdOrderForDriver(user);
        }
    }
}
