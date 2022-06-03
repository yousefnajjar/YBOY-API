using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.DTO;
using YBOY.Core.Repository;
using YBOY.Core.Service;

namespace YBOY.Infra.Service
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository _productRepository)
        {
           productRepository = _productRepository;
        }
        public List<Product> GetAllProduct()
        {
            return productRepository.GetAllProduct();
        }
        public List<Product> GetAllAvailableProduct()
        {
            return productRepository.GetAllAvailableProduct();
        }

        public List<CountOfCategory> GetAllAvailableCategoryProduct()
        {
            return productRepository.GetAllAvailableCategoryProduct();
        }

        public bool CreateProduct(Product product)
        {
            return productRepository.CreateProduct(product);
        }
        public bool UpdateProduct(Product product)
        {
            return productRepository.UpdateProduct(product);
        }
        public bool DeleteProduct(int id)
        {
            return productRepository.DeleteProduct(id);
        }
        public List<Product> SearchProduct(SearchProductDTO search)
        {
            return productRepository.SearchProduct(search);
        }
    }
}
