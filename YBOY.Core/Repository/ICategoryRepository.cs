using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Repository
{
    public interface ICategoryRepository
    {
        public List<Category> getAllCategory();

        public bool createCategory(Category category);

        public bool updateCategory(Category category);

        public bool deleteCategory(int id);

    }
}
