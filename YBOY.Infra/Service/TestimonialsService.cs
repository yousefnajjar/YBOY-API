using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.Repository;
using YBOY.Core.Service;

namespace YBOY.Infra.Service
{
    public class TestimonialsService : ITestimonialsService
    {
        private readonly ITestimonialsRepository testimonialsRepository;

        public TestimonialsService(ITestimonialsRepository _testimonialsRepository)
        {
            testimonialsRepository = _testimonialsRepository;
        }
        public List<Testimonials> GetAllTestimonial()
        {
            return testimonialsRepository.GetAllTestimonial();
        }
        public bool CreateTestimonial(Testimonials testimonials)
        {
            return testimonialsRepository.CreateTestimonial(testimonials);
        }
        public bool DeleteTestimonial(int id)
        {
            return testimonialsRepository.DeleteTestimonial(id);
        }

        public bool approveTestimonial(Testimonials testimonials)
        {
            return testimonialsRepository.approveTestimonial(testimonials);
        }

        public List<Testimonials> GetAllApproveTestimonial()
        {
            return testimonialsRepository.GetAllApproveTestimonial();
        }
        public List<Testimonials> GetAllPandingTestimonial()
        {
            return testimonialsRepository.GetAllPandingTestimonial();
        }
    }
}
