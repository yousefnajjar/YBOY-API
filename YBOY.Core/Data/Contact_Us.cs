using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YBOY.Core.Data
{
    public class Contact_Us
    {
        [Key]
        public int Contact_Us_id { get; set; }
        public string  Fname { get; set; }
        public string Lname { get; set; }
        public string email { get; set; }
        public string Message { get; set; }
        public int Web_id { get; set; }

        [ForeignKey("Web_id")]
        public virtual Website Website { get; set; }
    }
}
