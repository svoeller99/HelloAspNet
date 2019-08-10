using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloAspNet.Domain.Models;
using HelloAspNet.Domain.Services;
using HelloAspNet.Extensions;
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            // validate
            if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

            // map resource to entity model
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);

            // save to database
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                    return BadRequest(result.Message);

            // return created resource
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            // TODO: consolidate code duplication with PostAsync (only differs by what service method is called)

            if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                    return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }
    }
}