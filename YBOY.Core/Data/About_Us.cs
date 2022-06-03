using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YBOY.Core.Data
{
    public class About_Us
    {
        [Key]
        public int About_us_id { get; set; }
        public string Info { get; set; }

        public string  Image_path { get; set; }
        
        public int Web_id { get; set; }

        [ForeignKey("Web_id")]
        public virtual Website Website { get; set; }
    }
}
