using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YBOY.Core.Common;
using YBOY.Core.Data;
using YBOY.Core.Repository;

namespace YBOY.Infra.Repository
{
    public class TestimonialsRepository : ITestimonialsRepository
    {
        private readonly IDbContext dbContext;
        public TestimonialsRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
       public List<Testimonials> GetAllTestimonial()
        {
            IEnumerable<Testimonials> result = dbContext.Connection.Query<Testimonials>("TESTIMONIAL_PACKAGE.GetAllTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Testimonials> GetAllApproveTestimonial()
        {
            IEnumerable<Testimonials> result = dbContext.Connection.Query<Testimonials>("TESTIMONIAL_PACKAGE.GetAllApproveTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Testimonials> GetAllPandingTestimonial()
        {
            IEnumerable<Testimonials> result = dbContext.Connection.Query<Testimonials>("TESTIMONIAL_PACKAGE.GetAllPandingTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateTestimonial(Testimonials testimonials)
        {
            var p = new DynamicParameters();
            p.Add("fNAME_", testimonials.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("lNAME_", testimonials.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image_path_", testimonials.Image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("FEEDBACK_mess_", testimonials.Feedback_mess, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Status_", testimonials.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("WEB_ID_", testimonials.Web_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("TESTIMONIAL_PACKAGE.CreateTestimonial", p, commandType: CommandType.StoredProcedure);
            return true;
           
        }
        public bool DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("TESTIMONIAL_ID_", id , dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("TESTIMONIAL_PACKAGE.DeleteTestimonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        
        public bool approveTestimonial(Testimonials testimonials)
        {
            var p = new DynamicParameters();
            p.Add("TESTIMONIAL_ID_", testimonials.Testimonial_id, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("TESTIMONIAL_PACKAGE.approveTestimonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
