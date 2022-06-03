using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Repository
{
    public interface IWebsiteRepository
    {
        public List<Website> GetAllWebsite();
        public bool UpdateWebsite(Website website);

    }
}
