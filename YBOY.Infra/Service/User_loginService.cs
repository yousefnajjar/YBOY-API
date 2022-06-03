using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.DTO;
using YBOY.Core.Repository;
using YBOY.Core.Service;

namespace YBOY.Infra.Service
{
    public class User_loginService : IUser_loginService
    {
        private readonly IUser_loginRepository user_LoginRepository;

        public User_loginService(IUser_loginRepository _user_LoginRepository)
        {
            user_LoginRepository = _user_LoginRepository;
        }
        public List<User_login> GETALLUSER()
        {
            return user_LoginRepository.GETALLUSER();
        }
        public string CREATEUSER(User_login user)
        {
            return user_LoginRepository.CREATEUSER(user);
        }

        public bool UPDATUSER(User_login user)
        {
            return user_LoginRepository.UPDATUSER(user);
        }
        public User_login GETUSERBYEMAIL(User_login email)
        {
            return user_LoginRepository.GETUSERBYEMAIL(email);
        }
        public bool DELETEUSER(int id)
        {
            return user_LoginRepository.DELETEUSER(id);
        }
        public List<User_login> searchUsers(SearchUser searchUser)
        {
            return user_LoginRepository.searchUsers(searchUser);
        }
        public loginDTO Login(User_login user)
        {
            return user_LoginRepository.Login(user);
        }
        public string Auth(User_login login)
        {
            var result = user_LoginRepository.Login(login);
            if (result == null)//doesn't match any username and password in DB (Not Authorized User)
            {
                return null;
            }
            else
            {
                //1- token handler : اللي رح يعمل كريت للtoken
                var tokenhandler = new JwtSecurityTokenHandler();

                //2- token key : private key used in encryption method to encrypt data.

                var tokenKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]"));

                //3- descriptor : result(payload) + more prop.
                var tokendescriptor = new SecurityTokenDescriptor
                {
                    //subject : claimidentity
                    Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, result.User_email),
                    new Claim(ClaimTypes.Role, result.Role_name)
                }),
                    Expires = DateTime.UtcNow.AddYears(1),//session timeout
                    SigningCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256)
                };
                var token = tokenhandler.CreateToken(tokendescriptor);
                return tokenhandler.WriteToken(token); //return string value {Token}
            }
        }
    }
}
