using System.Collections.Generic;
using System.Threading.Tasks;
using HelloAspNet.Domain.Models;
using HelloAspNet.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloAspNet.Controllers
{
    [Route("/api/[controller]")] // apparently [controller] means lowercase class name minus "Controller" suffix
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync() {
            var categories = await _categoryService.ListAsync();
            return categories;
        }
    }
}