using System;
using System.Collections.Generic;
using System.Text;

namespace YBOY.Core.DTO
{
    public class OrderId
    {
        public int Order_id { get; set; }
        public int Quntity { get; set; }
        public float total_amount { get; set; }
        public int User_id { get; set; }
    }
}
