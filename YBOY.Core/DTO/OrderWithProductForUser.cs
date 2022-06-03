using System;
using System.Collections.Generic;
using System.Text;

namespace YBOY.Core.DTO
{
    public class OrderWithProductForUser
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int product_count { get; set; }
        public string product_name { get; set; }
        public float product_price { get; set; }
        public string image_path { get; set; }
        public string category_name { get; set; }
        public int Quntity { get; set; }
    }
}
