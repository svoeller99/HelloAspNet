using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloAspNet.Domain.Models;
using HelloAspNet.Domain.Services;
using HelloAspNet.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HelloAspNet.Controllers
{
    [Route("/api/[controller]")] // apparently [controller] means lowercase class name minus "Controller" suffix
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper) {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync() {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }
    }
}