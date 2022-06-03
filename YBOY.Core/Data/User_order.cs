using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YBOY.Core.Data
{
    public class User_order
    {
        [Key]
        public int Order_id { get; set; }
        public DateTime Order_Date { get; set; }
        public int Quntity { get; set; }
        public float Total_amount { get; set; }
        public string Status { get; set; }
        public int User_id { get; set; }

        [ForeignKey("User_id")]

        public virtual User_login User_Login { get; set; }

        public ICollection<Cart> cart { get; set; }
        public ICollection<Order_Product> Order_Product { get; set; }

    }
}
