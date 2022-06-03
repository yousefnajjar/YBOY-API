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
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        [Route("GetAllProduct")]
        public List<Product> GetAllProduct()
        {
            return productService.GetAllProduct();
        }

        [HttpGet]
        [Route("GetAllAvailableProduct")]
        public List<Product> GetAllAvailableProduct()
        {
            return productService.GetAllAvailableProduct();
        }

        [HttpGet]
        [Route("GetAllAvailableCategoryProduct")]
        public List<CountOfCategory> GetAllAvailableCategoryProduct()
        {
            return productService.GetAllAvailableCategoryProduct();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public bool CreateProduct(Product product)
        {
            return productService.CreateProduct(product);
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public bool UpdateProduct(Product product)
        {
            return productService.UpdateProduct(product);
        }
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public bool DeleteProduct(int id)
        {
            return productService.DeleteProduct(id);
        }
        [HttpPost]
        [Route("SearchProduct")]
        public List<Product> SearchProduct(SearchProductDTO search)
        {
            
            return productService.SearchProduct(search);
        }

        [HttpPost]
        [Route("UploadProductImage")]
        public Product UploadProductImage()
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
                Product product = new Product();
                product.Image_path = fileName;
                return product;

            }
            catch (Exception e)
            {
                return null;
            }
        }




    }
}
