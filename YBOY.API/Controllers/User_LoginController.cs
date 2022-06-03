using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using YBOY.Core.Data;
using YBOY.Core.DTO;
using YBOY.Core.Service;

namespace YBOY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_LoginController : ControllerBase
    {
        private readonly IUser_loginService user_LoginService;
        public User_LoginController(IUser_loginService _user_LoginService)
        {
           user_LoginService = _user_LoginService;
        }
        [HttpGet]
        [Route("GETALLUSER")]
        public List<User_login> GETALLUSER()
        {
            return user_LoginService.GETALLUSER();
        }

        [HttpPost]
        [Route("searchUsers")]
        public List<User_login> searchUsers(SearchUser searchUser)
        {
            return user_LoginService.searchUsers(searchUser);
        }
        [HttpPost]
        [Route("CREATEUSER")]
        public string CREATEUSER(User_login user)
        {
            return user_LoginService.CREATEUSER(user);  
        }
        [HttpPut]
        [Route("UPDATUSER")]
        public bool UPDATUSER(User_login user)
        {
            return user_LoginService.UPDATUSER(user);
        }
        [HttpDelete]
        [Route("DELETEUSER/{id}")]
        public bool DELETEUSER(int id)
        {
            return user_LoginService.DELETEUSER(id);
        }
        [HttpPost]
        [Route("GETUSERBYEMAIL")]
        public User_login GETUSERBYEMAIL(User_login email)
        {
            return user_LoginService.GETUSERBYEMAIL(email);
        }
        [HttpPost]
        [Route("Auth")]
        public IActionResult Auth(User_login login)
        {
            var token = user_LoginService.Auth(login);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }

        [HttpPost]
        [Route("UploadUserImage")]
        public User_login UploadUserImage()
        {
            try
            {
                // Image -----> Request ----> Form
                var file = Request.Form.Files[0];

                // file.FileName
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // create folder "Images" in Tahaluf.LMS.API
                var fullPath = Path.Combine("C:\\Users\\User\\Videos\\YBOY-Angular\\src\\assets\\Images", fileName);

                // FileStream
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // DataBase
                User_login userlogin = new User_login();
                userlogin.User_imagepath = fileName;
                return userlogin;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
