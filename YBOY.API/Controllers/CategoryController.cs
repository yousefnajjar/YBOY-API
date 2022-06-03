using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YBOY.Core.Data;
using YBOY.Core.Service;

namespace YBOY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
       
        [HttpGet]
        [Route("getAllCategory")]
        public List<Category> getAllCategory()
        {
            return categoryService.getAllCategory();    
        }
        [HttpPost]
        [Route("createCategory")]
        public bool createCategory(Category category)
        {
            return categoryService.createCategory(category);
        }
        [HttpPut]
        [Route("updateCategory")]
        public bool updateCategory(Category category)
        {
            return categoryService.updateCategory(category);
        }
        [HttpDelete]
        [Route("deleteCategory/{id}")]
        public bool deleteCategory(int id)
        {
            return categoryService.deleteCategory(id);
        }
    }
}
