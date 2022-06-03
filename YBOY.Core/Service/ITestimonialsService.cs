using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Service
{
    public interface ITestimonialsService
    {
        public List<Testimonials> GetAllTestimonial();
        public List<Testimonials> GetAllApproveTestimonial();
        public bool CreateTestimonial(Testimonials testimonials);
        public bool DeleteTestimonial(int id);

        public bool approveTestimonial(Testimonials testimonials);
        public List<Testimonials> GetAllPandingTestimonial();
    }
}
