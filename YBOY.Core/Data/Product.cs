using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YBOY.Core.Data
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public float Product_price { get; set; }
        public int Product_quntity { get; set; }
        public string Is_available { get; set; }
        public string Image_path { get; set; }

        public string Category_name { get; set; }
        public int Category_id { get; set; }
        [ForeignKey("Category_id")]
        public virtual Category Category { get; set; }

        public string Product_description { get; set; }
        public ICollection<Order_Product> Order_Product { get; set; }
    }
}
