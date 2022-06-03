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
   public class LocationRepository   : ILocationRepository
    {
        private readonly IDbContext dbContext;

        public LocationRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        //Fix
        public Location getLocationByUserId(Location location)
        {
            var p = new DynamicParameters();
            p.Add("user_id_", location.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Location>("location_package.getLocationByUserId",p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool createLocation(Location location)
        {
            var p = new DynamicParameters();
            p.Add("city_", location.City, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("street_", location.Street, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("area_", location.Area, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("apartment_number_", location.Apartment_number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("floor_", location.Floor, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone_", location.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_id_", location.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("location_package.createLocation", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateLocation(Location location)
        {
            var p = new DynamicParameters();
            
            p.Add("city_", location.City, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("street_", location.Street, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("area_", location.Area, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("apartment_number_", location.Apartment_number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("floor_", location.Floor, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone_", location.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_id_", location.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("location_package.updateLocation", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
