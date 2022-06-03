using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using YBOY.Core.Data;
using YBOY.Core.Service;

namespace YBOY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class About_UsController : ControllerBase
    {

        private readonly IAbout_UsService about_UsService;

        public About_UsController(IAbout_UsService _about_UsService)
        {
            about_UsService = _about_UsService;
        }

        [HttpGet]
        [Route("getAllAboutUs")]
        public List<About_Us> getAllAboutUs()
        {
            return about_UsService.getAllAboutUs();
        }
        [HttpPost]
        [Route("CreateAboutUs")]
        public bool CreateAboutUs(About_Us about_Us)
        {
            return about_UsService.CreateAboutUs(about_Us);
        }
        [HttpPut]
        [Route("UpdateAboutUs")]
        public bool UpdateAboutUs(About_Us about_Us)
        {
            return about_UsService.UpdateAboutUs(about_Us);
        }
        [HttpDelete]
        [Route("DeleteAboutUs/{id}")]
        public string DeleteAboutUs(int id)
        {
            return about_UsService.DeleteAboutUs(id);
        }


        [HttpPost]
        [Route("UploadAboutusImage")]
        public About_Us UploadAboutusImage()
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
                About_Us about = new About_Us();
                about.Image_path = fileName;
                return about;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
