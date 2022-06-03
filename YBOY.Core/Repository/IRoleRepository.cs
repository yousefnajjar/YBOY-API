using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Repository
{
    public interface IRoleRepository
    {

        public List<Role> GetAllRole();
    }
}
