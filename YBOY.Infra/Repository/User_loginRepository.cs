using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YBOY.Core.Common;
using YBOY.Core.Data;
using YBOY.Core.DTO;
using YBOY.Core.Repository;

namespace YBOY.Infra.Repository
{
    public class User_loginRepository : IUser_loginRepository
    {
        private readonly IDbContext dbContext;
        public User_loginRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<User_login> GETALLUSER()
        {
            IEnumerable<User_login> users = dbContext.Connection.Query<User_login>("USER_LOGIN_PACKAGE.GETALLUSER", commandType: CommandType.StoredProcedure);

            IEnumerable<Role> roles = dbContext.Connection.Query<Role>("ROLE_PACKAGE.GETALLROLE", commandType: CommandType.StoredProcedure);

            List<User_login> allUser = new List<User_login>();
            List<Role> allRole = new List<Role>();

            allUser = users.ToList();
            allRole = roles.ToList();

            for (int i = 0; i < allUser.Count(); i++)
            {
                for (int j = 0; j < allRole.Count(); j++)
                {
                    if (allUser[i].Role_id == allRole[j].Role_id)
                    {
                        allUser[i].Role_name = allRole[j].Role_name;
                    }
                }
            }





            return allUser;
        }

        public List<User_login> searchUsers(SearchUser searchUser)
        {
            var p = new DynamicParameters();
            p.Add("fullname_", searchUser.fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            

            IEnumerable<User_login> users = dbContext.Connection.Query<User_login>("USER_LOGIN_PACKAGE.searchUsers", p, commandType: CommandType.StoredProcedure);
            IEnumerable<Role> roles = dbContext.Connection.Query<Role>("ROLE_PACKAGE.GETALLROLE", commandType: CommandType.StoredProcedure);

            List<User_login> allUser = new List<User_login>();
            List<Role> allRole = new List<Role>();

            allUser = users.ToList();
            allRole = roles.ToList();

            for (int i = 0; i < allUser.Count(); i++)
            {
                for (int j = 0; j < allRole.Count(); j++)
                {
                    if (allUser[i].Role_id == allRole[j].Role_id)
                    {
                        allUser[i].Role_name = allRole[j].Role_name;
                    }
                }
            }


            return allUser;

        }

        public string CREATEUSER(User_login user)
        {
            var p = new DynamicParameters();
            p.Add("FIRSTNAME_", user.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LASTNAME_", user.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASSWORD_", user.User_password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONENUMBER_", user.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EMAIL_", user.User_email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE_", user.User_imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLE_ID_", user.Role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("USER_LOGIN_PACKAGE.CREATEUSER", p, commandType: CommandType.StoredProcedure);

            return result.Status.ToString();
            
        }

        public bool UPDATUSER(User_login user)
        {
            var p = new DynamicParameters();
            p.Add("USER_ID_", user.User_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FIRSTNAME_", user.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LASTNAME_", user.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASSWORD_", user.User_password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONENUMBER_", user.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EMAIL_", user.User_email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE_", user.User_imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLE_ID_", user.Role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("USER_LOGIN_PACKAGE.UPDATUSER", p, commandType: CommandType.StoredProcedure);

            return true;

        }
        public bool DELETEUSER(int id)
        {
            var p = new DynamicParameters();
            p.Add("USER_ID_", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("USER_LOGIN_PACKAGE.DELETEUSER", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public loginDTO Login(User_login user)
        {
            var p = new DynamicParameters();
            p.Add("email_", user.User_email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("password_", user.User_password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<loginDTO> result = dbContext.Connection.Query<loginDTO>("USER_LOGIN_PACKAGE.Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault(); 
        }

        public User_login GETUSERBYEMAIL(User_login email)
        {
            var p = new DynamicParameters();
            p.Add("email_", email.User_email, dbType: DbType.String, direction: ParameterDirection.Input);
       

            IEnumerable<User_login> result = dbContext.Connection.Query<User_login>("USER_LOGIN_PACKAGE.GETUSERBYEMAIL", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        

    }
}