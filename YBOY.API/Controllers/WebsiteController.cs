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
    public class WebsiteController : ControllerBase
    {
        private readonly IWebsiteService Website; 
        public WebsiteController (IWebsiteService _Website)
        {
            Website = _Website;
        }
        [HttpGet]
        [Route("GetAllWebsite")]
        public List<Website> GetAllWebsite()
        {
            return Website.GetAllWebsite();
        }
        [HttpPut]
        [Route("UpdateWebsite")]
        public bool UpdateWebsite(Website website)
        {
            return Website.UpdateWebsite(website);
        }

        [HttpPost]
        [Route("UploadLogoImage")]
        public Website UploadLogoImage()
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
                Website web = new Website();
                web.Web_image_logo_path = fileName;
                return web;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
