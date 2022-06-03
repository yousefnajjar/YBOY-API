using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.DTO;

namespace YBOY.Core.Repository
{
    public interface IUser_loginRepository
    {

        public List<User_login> GETALLUSER();
        public List<User_login> searchUsers(SearchUser searchUser);
        public string CREATEUSER(User_login user);

        public bool UPDATUSER(User_login user);
        public bool DELETEUSER(int id);
        public loginDTO Login(User_login user);

        public User_login GETUSERBYEMAIL(User_login email);
    }
}
