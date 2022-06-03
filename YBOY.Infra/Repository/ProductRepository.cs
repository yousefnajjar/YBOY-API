using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YBOY.Core.Common;
using YBOY.Core.Data;
using YBOY.Core.DTO;
using YBOY.Core.Repository;

namespace YBOY.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext dbContext;
        public ProductRepository (IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<Product> GetAllProduct()
        {
            IEnumerable<Product> products = dbContext.Connection.Query<Product>("product_package.GetAllProduct", commandType: CommandType.StoredProcedure);

            IEnumerable<Category> categorys = dbContext.Connection.Query<Category>("category_package.GetAllCategory", commandType: CommandType.StoredProcedure);

            List<Product> allProduct = new List<Product>();
            List<Category> allCategory = new List<Category>();

            allProduct = products.ToList();
            allCategory = categorys.ToList();

            for (int i = 0; i < allProduct.Count(); i++)
            {
                for (int j = 0; j < allCategory.Count(); j++)
                {
                    if(allProduct[i].Category_id == allCategory[j].Category_id)
                    {
                        allProduct[i].Category_name = allCategory[j].Category_name;
                    }
                }
            }


            return allProduct;
        }
        public List<Product> GetAllAvailableProduct()
        {
            IEnumerable<Product> products = dbContext.Connection.Query<Product>("product_package.GetAllAvailableProduct", commandType: CommandType.StoredProcedure);

            IEnumerable<Category> categorys = dbContext.Connection.Query<Category>("category_package.GetAllCategory", commandType: CommandType.StoredProcedure);

            List<Product> allProduct = new List<Product>();
            List<Category> allCategory = new List<Category>();

            allProduct = products.ToList();
            allCategory = categorys.ToList();

            for (int i = 0; i < allProduct.Count(); i++)
            {
                for (int j = 0; j < allCategory.Count(); j++)
                {
                    if (allProduct[i].Category_id == allCategory[j].Category_id)
                    {
                        allProduct[i].Category_name = allCategory[j].Category_name;
                    }
                }
            }


            return allProduct;
        }


        public List<CountOfCategory> GetAllAvailableCategoryProduct()
        {
            IEnumerable<CountOfCategory> count = 
                dbContext.Connection.Query<CountOfCategory>("product_package.GetAllAvailableCategoryProduct", commandType: CommandType.StoredProcedure);

            
            return count.ToList();
        }


        public bool CreateProduct(Product product)
        {
            var p = new DynamicParameters();
            p.Add("product_name_", product.Product_name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("product_price_", product.Product_price, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("product_quntity_",product.Product_quntity , dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("category_id_", product.Category_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("is_available_",product.Is_available, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image_path_", product.Image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("product_description_",product.Product_description,  dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("product_package.CreateProduct", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateProduct(Product product)
        {
            var p = new DynamicParameters();
            p.Add("product_id_", product.Product_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("product_name_", product.Product_name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("product_price_", product.Product_price, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("category_id_", product.Category_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("product_quntity_", product.Product_quntity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("is_available_", product.Is_available, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image_path_", product.Image_path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("product_description_", product.Product_description, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("product_package.UpdateProduct", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var p = new DynamicParameters();
            p.Add("product_id_", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("product_package.DeleteProduct", p, commandType: CommandType.StoredProcedure);
            return true;

        }
        public List<Product> SearchProduct(SearchProductDTO search )
        {
            var p = new DynamicParameters();
            p.Add("product_name_", search.Product_name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("product_description_", search.Product_description, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Product> result = dbContext.Connection.Query<Product>("product_package.SearchProduct", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
