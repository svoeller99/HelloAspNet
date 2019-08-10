using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloAspNet.Domain.Models;
using HelloAspNet.Domain.Services;
using HelloAspNet.Domain.Services.Communication;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id) {
            var category = await _categoryService.FindByIdAsync(id);

            if (category == null)
                    return NotFound();

            var resource = _mapper.Map<Category, CategoryResource>(category);
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            return await SaveAsync(resource, (category) => {
                return _categoryService.SaveAsync(category);
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            return await SaveAsync(resource, (category) => {
                return _categoryService.UpdateAsync(id, category);
            });
        }

        private async Task<IActionResult> SaveAsync(SaveCategoryResource resource, Func<Category, Task<CategoryResponse>> saveFunction)
        {
            // validate
            if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

            // map resource to entity model
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);

            // save to database
            var result = await saveFunction.Invoke(category);

            if (!result.Success)
                    return BadRequest(result.Message);

            // return created resource
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                    return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }
    }
}