
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
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialsService testimonialsService;

        public TestimonialController(ITestimonialsService _testimonialsService)
        {
            testimonialsService = _testimonialsService;
        }
        [HttpGet]
        [Route("GetAllTestimonial")]
        public List<Testimonials> GetAllTestimonial()
        {
            return testimonialsService.GetAllTestimonial();
        }

        [HttpGet]
        [Route("GetAllApproveTestimonial")]
        public List<Testimonials> GetAllApproveTestimonial()
        {
            return testimonialsService.GetAllApproveTestimonial();
        }
        [HttpGet]
        [Route("GetAllPandingTestimonial")]
        public List<Testimonials> GetAllPandingTestimonial()
        {
            return testimonialsService.GetAllPandingTestimonial();
        }
        [HttpPost]
        [Route("CreateTestimonial")]                              
        public bool CreateTestimonial(Testimonials testimonials)
        {
            return testimonialsService.CreateTestimonial(testimonials);
        }
        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]
        public bool DeleteTestimonial(int id)
        {
            return testimonialsService.DeleteTestimonial(id);
        }
        [HttpPut]
        [Route("approveTestimonial")]
        public bool approveTestimonial(Testimonials testimonials)
        {
            return testimonialsService.approveTestimonial(testimonials);
        }

        [HttpPost]
        [Route("UploadTestimonialImage")]
        public Testimonials UploadTestimonialImage()
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
                Testimonials testimonial = new Testimonials();
                testimonial.Image_path = fileName;
                return testimonial;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
