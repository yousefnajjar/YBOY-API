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
    public class RoleRepository  : IRoleRepository
    {

        private readonly IDbContext dbContext;

        public RoleRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Role> GetAllRole()
        {
            IEnumerable<Role> result = dbContext.Connection.Query<Role>("ROLE_PACKAGE.GETALLROLE",commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
            



    }
}
