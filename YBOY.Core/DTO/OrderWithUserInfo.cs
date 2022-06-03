using System;
using System.Collections.Generic;
using System.Text;

namespace YBOY.Core.DTO
{
    public class OrderWithUserInfo
    {
        public int Order_id { get; set; }
        public int user_id { get; set; }
        public DateTime Order_Date { get; set; }
        public int Quntity { get; set; }
        public float Total_amount { get; set; }
        public string Status { get; set; }
        public string payment_Status { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string user_email { get; set; }
        public string phone { get; set; }
    }
}
