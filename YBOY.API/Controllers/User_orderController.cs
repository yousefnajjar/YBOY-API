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
    public class User_orderController : ControllerBase
    {
        private readonly IUser_orderService user_OrderService;
        public User_orderController(IUser_orderService _user_OrderService)
        {
            user_OrderService = _user_OrderService;
        }
        [HttpGet]
        [Route("GetAllorder")]
        public List<User_order> GetAllorder()
        {
            return user_OrderService.GetAllorder();
        }

        

        [HttpGet]
        [Route("GetAllDeliveredorderWithUserInfo")]
        public List<OrderWithUserInfo> GetAllDeliveredorderWithUserInfo()
        {
            return user_OrderService.GetAllDeliveredorderWithUserInfo();
        }

        [HttpGet]
        [Route("GetAllPendingorderWithUserInfo")]
        public List<OrderWithUserInfo> GetAllPendingorderWithUserInfo()
        {
            return user_OrderService.GetAllPendingorderWithUserInfo();
        }

        [HttpPost]
        [Route("GetAllOrderWithproduct")]
        public List<OrderWithProduct> GetAllOrderWithproduct(OrderWithProduct orderWithProduct)
        {
            return user_OrderService.GetAllOrderWithproduct(orderWithProduct);
        }


        [HttpPost]
        [Route("Createorder")]

        public OrderId Createorder(User_order user)
        {
            return user_OrderService.Createorder(user);
        }
        [HttpPut]
        [Route("Updateorder")]
        public bool Updateorder(User_order user)
        {
            return user_OrderService.Updateorder(user);
        }
        [HttpDelete]
        [Route("Deleteorder/{id}")]

        public bool Deleteorder(int id)
        {
            return user_OrderService.Deleteorder(id);
        }

        [HttpPut]
        [Route("StatusUpdate")]
        public bool StatusUpdate(statusUpdate statusUpdate)
        {
            return user_OrderService.StatusUpdate(statusUpdate);
        }

        [HttpGet]
        [Route("GetAllAcceptedorder")]
        public List<OrderWithUserInfo> GetAllAcceptedorder()
        {
            return user_OrderService.GetAllAcceptedorder();
        }
        [HttpGet]
        [Route("GetAllReadyForDeliveredorder")]
        public List<OrderWithUserInfo> GetAllReadyForDeliveredorder()
        {
            return user_OrderService.GetAllReadyForDeliveredorder();
        }

        [HttpPost]
        [Route("GetAllProductForUser")]
        public List<OrderWithProductForUser> GetAllProductForUser(User_order user)
        {
            return user_OrderService.GetAllProductForUser(user);
        }
        [HttpPost]
        [Route("GetAllOrderForUser")]
        public List<OrderId> GetAllOrderForUser(User_order user)
        {
            return user_OrderService.GetAllOrderForUser(user);
        }

        [HttpPut]
        [Route("UpdateOrder_quntityAndTotal_amount")]
        public bool UpdateOrder_quntityAndTotal_amount(List<OrderId> orderIds)
        {
            return user_OrderService.UpdateOrder_quntityAndTotal_amount(orderIds);
        }
        [HttpPut]
        [Route("Plus_")]
        public bool Plus_(OrderWithProductForUser orderWithProductForUser)
        {
            return user_OrderService.Plus_(orderWithProductForUser);
        }
        [HttpPut]
        [Route("Minus_")]
        public bool Minus_(OrderWithProductForUser orderWithProductForUser)
        {
            return user_OrderService.Minus_(orderWithProductForUser);
        }
        [HttpPut]
        [Route("UpdateOrder_Total_amount")]
        public bool UpdateOrder_Total_amount(updateTotalAmountDependeOnMeal updateTotalAmountDependeOnMeals)
        {
            return user_OrderService.UpdateOrder_Total_amount(updateTotalAmountDependeOnMeals);
        }
        [HttpPut]
        [Route("statusPendingAndPaymentOnline")]
        public bool statusPendingAndPaymentOnline(List<OrderId> orderIds)
        {
            return user_OrderService.statusPendingAndPaymentOnline(orderIds);
        }

        [HttpPut]
        [Route("statusPendingAndPaymentCash")]
        public bool statusPendingAndPaymentCash(List<OrderId> orderIds)
        {
            return user_OrderService.statusPendingAndPaymentCash(orderIds);
        }
        [HttpPost]
        [Route("GetAllOrderReadyForUser")]
        public List<OrderId> GetAllOrderReadyForUser(User_order user)
        {
            return user_OrderService.GetAllOrderReadyForUser(user);
        }
        [HttpPost]
        [Route("CreateDriver_order")]
        public bool CreateDriver_order(userAndDriverId userAndDriverId)
        {
            return user_OrderService.CreateDriver_order(userAndDriverId);
        }
        [HttpPost]
        [Route("GetAllAcceptedOrderFromDriver")]
        public List<OrderWithUserInfo> GetAllAcceptedOrderFromDriver(User_order user)
        {
            return user_OrderService.GetAllAcceptedOrderFromDriver(user);
        }
        [HttpPost]
        [Route("GetAllDeliverdOrderForDriver")]
        public List<OrderWithUserInfo> GetAllDeliverdOrderForDriver(User_order user)
        {
            return user_OrderService.GetAllDeliverdOrderForDriver(user);
        }

    }
}
