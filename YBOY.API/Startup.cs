using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBOY.Core.Common;
using YBOY.Core.DTO;
using YBOY.Core.Repository;
using YBOY.Core.Service;
using YBOY.Infra.Common;
using YBOY.Infra.Repository;
using YBOY.Infra.Service;

namespace YBOY.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("x",
                builder =>
                {
                    //builder.WithOrigins("http://127.0.0.1:4200", "http://localhost:4200", "https://localhost:4200")
                    // .AllowAnyHeader()
                    // .AllowAnyMethod();


                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });


            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAbout_UsRepository, About_UsRepository>();
            services.AddScoped<IAbout_UsService, About_UsService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContact_UsService, Contact_UsService>();
            services.AddScoped<IContact_UsRepository, Contact_UsRepository>();
            services.AddScoped<IOrder_ProductRepository, Order_ProductRepository>();
            services.AddScoped<IOrder_ProductService, Order_ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();    
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITestimonialsService, TestimonialsService>();
            services.AddScoped<ITestimonialsRepository, TestimonialsRepository>();
            services.AddScoped<IUser_loginService, User_loginService>();
            services.AddScoped<IUser_loginRepository, User_loginRepository>();
            services.AddScoped<IUser_orderRepository, User_orderRepository>();
            services.AddScoped<IUser_orderService, User_orderService>();
            services.AddScoped<IWebsiteRepository, WebsiteRepository>();
            services.AddScoped<IWebsiteService, WebsiteService>();

            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationService, LocationService>();

            services.AddScoped<IMailService, MailService>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
         
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("x");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
