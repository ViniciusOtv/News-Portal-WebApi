using System.Linq;
using New_Portal_Web_API.Models;
using System.Collections.Generic;
using New_Portal_Web_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace New_Portal_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : Controller
    {
        private List<Category> _category;
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            _category = _categoryRepository.GetAllCategories().ToList();

            if (_category == null || !_category.Any())
            {
                return NotFound();
            }

            return Ok(_category);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            _category = _categoryRepository.GetCategoryById(id).ToList();

            if (_category == null || !_category.Any())
            {
                return NotFound();
            }

            return Ok(_category);

        }
    }
}