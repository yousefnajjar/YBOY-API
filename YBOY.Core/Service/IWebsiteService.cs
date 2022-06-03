using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Service
{
   public  interface IWebsiteService
    {
      
        public List<Website> GetAllWebsite();
        public bool UpdateWebsite(Website website);

    }
}
