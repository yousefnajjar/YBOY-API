using System;
using System.Collections.Generic;
using System.Text;

namespace YBOY.Core.DTO
{
    public class OrderWithProduct
    {
        public int id { get; set; }
        public int product_count { get; set; }
        public string product_name { get; set; }
        public string product_price { get; set; }
        public string image_path { get; set; }
    }
}
