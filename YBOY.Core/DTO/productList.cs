using System;
using System.Collections.Generic;
using System.Text;

namespace YBOY.Core.DTO
{
    public class productList
    {
        public List<Int32> Product_id { get; set; }

        public int User_id { get; set; }
        public List<float> product_price { get; set; }
    }
}
