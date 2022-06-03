using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YBOY.Core.Data
{
    public class Cart
    {
        [Key]
        public int Cart_id { get; set; }
        public int Order_id { get; set; }
        public int User_id { get; set; }

        [ForeignKey("Order_id")]
        public virtual User_order User_Order { get; set; }

        [ForeignKey("User_id")]
        public virtual User_login User_Login  { get; set; }

    }
}
