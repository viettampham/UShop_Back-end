using System;
using beSS.Models.RequestModels;
using beSS.Services;
using Microsoft.AspNetCore.Mvc;

namespace beSS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController:ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get-category")]
        public IActionResult GetCategory()
        {
            var listCategory = _categoryService.GetCategory();
            return Ok(listCategory);
        }

        [HttpPost("add-category")]
        public IActionResult AddCategory(CreateCategory request)
        {
            var newCategory = _categoryService.CreateCategory(request);
            return Ok(newCategory);
        }

        [HttpPost("edit-category")]
        public IActionResult EditCategory(EditCategory request)
        {
            var targetCategory = _categoryService.EditCategory(request);
            return Ok(targetCategory);
        }
        
        [HttpDelete("delete-category/{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var targetCategory = _categoryService.DeleteCategory(id);
            return Ok(targetCategory);
        }
    }
}