using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YBOY.Core.Data
{
    public class User_login
    {
        [Key]
        public int User_id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string User_email { get; set; }
        public string phone { get; set; }

        public string User_password { get; set; }
        public string User_imagepath { get; set; }
        public int Role_id { get; set; }

        public string Role_name { get; set; }
        [ForeignKey("Role_id")]

        public virtual Role Role { get; set; }

        public ICollection<Location> locations { get; set; }
        public ICollection<User_order> user_Orders { get; set; }
        public ICollection<Cart> cart { get; set; }
    }
}
