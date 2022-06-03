using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.Repository;
using YBOY.Core.Service;

namespace YBOY.Infra.Service
{
   public  class WebsiteService : IWebsiteService
    {
        private readonly IWebsiteRepository Website;
        public WebsiteService(IWebsiteRepository _Website)
        {
            Website = _Website;
        }
        public List<Website> GetAllWebsite()
        {
            return Website.GetAllWebsite();
        }
        public bool UpdateWebsite(Website website)
        {
            return Website.UpdateWebsite(website);
        }
    }
}
