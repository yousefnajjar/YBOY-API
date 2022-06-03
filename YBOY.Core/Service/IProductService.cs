using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.DTO;

namespace YBOY.Core.Service
{
    public interface IProductService
    {
        public List<Product> GetAllProduct();
        public List<Product> GetAllAvailableProduct();
        public List<CountOfCategory> GetAllAvailableCategoryProduct();
        public bool CreateProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(int id);
        public List<Product> SearchProduct(SearchProductDTO search);
    }
}
