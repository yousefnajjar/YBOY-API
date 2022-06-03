using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YBOY.Core.Data
{
    public class Order_Product
    {
        [Key]
        public int Order_Product_id { get; set; }
        public int Order_id { get; set; }
        public int Product_id { get; set; }

        [ForeignKey("Order_id")]

        public virtual User_order User_Order { get; set; }
        [ForeignKey("Product_id")]

        public virtual Product Product { get; set; }

    }
}
