using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YBOY.Core.Data
{
    public class Role
    {
        [Key]
        public int Role_id { get; set; }
        public string Role_name { get; set; }

       public ICollection<User_login> user_login { set; get; }
    }
}
