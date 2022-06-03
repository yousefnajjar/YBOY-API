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
    public class About_UsRepository : IAbout_UsRepository
    {
        private readonly IDbContext dbContext;

        public About_UsRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<About_Us> getAllAboutUs()
        {
            IEnumerable<About_Us> result = dbContext.Connection.Query<About_Us>("about_us_package.GetAllAboutus", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateAboutUs(About_Us about_Us)
        {
            var p = new DynamicParameters();
            p.Add("info_", about_Us.Info, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image_path_", about_Us.Image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("web_id_", about_Us.Web_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.ExecuteAsync("about_us_package.CreateAboutus", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool UpdateAboutUs(About_Us about_Us)
        {
            var p = new DynamicParameters();

            p.Add("ABOUT_US_ID_", about_Us.About_us_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("info_", about_Us.Info, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image_path_", about_Us.Image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("web_id_", about_Us.Web_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("about_us_package.UpdateAboutus", p, commandType: CommandType.StoredProcedure);
            return true;

        }

        public string DeleteAboutUs(int id)
        {
            var p = new DynamicParameters();
            p.Add("ABOUT_US_ID_", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("about_us_package.DeleteAboutus", p, commandType: CommandType.StoredProcedure);
            return "deleted successfuly";
        }

    }
}