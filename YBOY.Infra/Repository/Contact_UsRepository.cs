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
    public class Contact_UsRepository : IContact_UsRepository
    {
        private readonly IDbContext dbContext;

        public Contact_UsRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

       

        public List<Contact_Us> getAllContact_Us()
        {
            IEnumerable<Contact_Us> result = dbContext.Connection.Query<Contact_Us>("Contact_Us_Package.GetAllContact_Us", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateContact_Us(Contact_Us contact_Us)
        {
            var p = new DynamicParameters();
            p.Add("fname_", contact_Us.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("lname_", contact_Us.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("email_", contact_Us.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("message_", contact_Us.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("web_id_", contact_Us.Web_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Contact_Us_Package.CreateContact_Us", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateContact_Us(Contact_Us contact_Us)
        { 
            var p = new DynamicParameters();
            p.Add("contact_us_id_", contact_Us.Contact_Us_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("fname_", contact_Us.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("lname_", contact_Us.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("email_", contact_Us.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("message_", contact_Us.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("web_id_", contact_Us.Web_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Contact_Us_Package.UpdateContact_Us", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public string DeleteContact_Us(int id)
        {
            var p = new DynamicParameters();
            p.Add("contact_us_id_", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Contact_Us_Package.DeleteContact_Us", p, commandType: CommandType.StoredProcedure);
            return "Deleted Succssfuly";
        }
    }
}
