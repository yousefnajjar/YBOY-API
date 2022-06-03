using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Repository
{
    public interface ITestimonialsRepository
    {
        public List<Testimonials> GetAllTestimonial();
        public bool CreateTestimonial(Testimonials testimonials);
        public bool DeleteTestimonial(int id);
        public bool approveTestimonial(Testimonials testimonials);
        public List<Testimonials> GetAllApproveTestimonial();
        public List<Testimonials> GetAllPandingTestimonial();


    }
}
