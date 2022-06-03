using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YBOY.Core.Data
{
    public class Location
    {
        [Key]
       
        public string City { get; set; }
        public string Area  { get; set; }
        public string Apartment_number  { get; set; }
        public string Street  { get; set; }
        public string Floor  { get; set; }
        public string phone { get; set; }
        public int User_id { get; set; }
        
        [ForeignKey("User_id")]

        public virtual User_login User_Login { get; set; }
    }
}
