using System;
using System.Collections.Generic;
using System.Text;

namespace YBOY.Core.DTO
{
    public class statusUpdate
    {
        public int user_id { get; set; }
        public string status { get; set; }

        public List<OrderWithUserInfo> orderWithUserInfos { get; set; }
    }
}
