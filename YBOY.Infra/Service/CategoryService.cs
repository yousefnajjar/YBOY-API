using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.Repository;
using YBOY.Core.Service;
using YBOY.Infra.Repository;

namespace YBOY.Infra.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
      
        public List<Category> getAllCategory()
        {
            return categoryRepository.getAllCategory();
        }

        public bool createCategory(Category category)
        {
            return categoryRepository.createCategory(category);
        }

        public bool updateCategory(Category category)
        {
            return categoryRepository.updateCategory(category); 
        }

        public bool deleteCategory(int id)
        {
            return categoryRepository.deleteCategory(id);
        }
    }
}
