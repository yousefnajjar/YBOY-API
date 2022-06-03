using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YBOY.Core.Common;
using YBOY.Core.Data;
using YBOY.Core.Repository;

namespace YBOY.Infra.Repository
{
    public class WebsiteRepository : IWebsiteRepository
    {
        private readonly IDbContext dbContext;
        public WebsiteRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Website> GetAllWebsite()
        {
            IEnumerable<Website> result = dbContext.Connection.Query<Website>("WEBSITE_Package.GetAllWebsite", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateWebsite(Website website)
        {
            var p = new DynamicParameters();
            p.Add("website_ID_", website.Web_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("website_Name_", website.Web_name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("logo_", website.Web_image_logo_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("background_", website.Web_image_background_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Address_", website.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PhonNumber_", website.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Email_", website.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("card_", website.Card_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("WEBSITE_Package.UpdateWebsite", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
