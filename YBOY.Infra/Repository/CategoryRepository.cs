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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext dbContext;

        public CategoryRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

       
        public List<Category> getAllCategory()
        {
            IEnumerable<Category> result = dbContext.Connection.Query<Category>("category_package.GetAllCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool createCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("category_name_", category.Category_name, dbType: DbType.String, direction: ParameterDirection.Input);
            

            var result = dbContext.Connection.ExecuteAsync("category_package.createCategory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateCategory(Category category)
        {
            var p = new DynamicParameters();
            
            p.Add("category_id_", category.Category_id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("category_name_", category.Category_name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("category_package.UpdateCategory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool deleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("category_id_", id, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("category_package.DeleteCategory", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
    }

