using System;
using System.Collections.Generic;
using System.Text;

namespace YBOY.Core.DTO
{
    public class updateTotalAmountDependeOnMeal
    {
        public List<OrderWithProductForUser>  orderWithProductForUsers { get; set; }
        public int order_id { get; set; }
        public int Quntity { get; set; }
        public string Status { get; set; }
    }
}
