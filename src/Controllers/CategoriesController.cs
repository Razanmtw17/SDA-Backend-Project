using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDA_Backend_Project.src.Services.Category;
using SDA_Backend_Project.src.Services.SubCategory;
using static SDA_Backend_Project.src.DTO.CategoryDTO;

namespace SDA_Backend_Project.src.Controllers
{
     [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriesController : ControllerBase
    {
          protected readonly ICategoryService _categoryService;
        protected readonly ISubCategoryService _subCategoryService;

        public CategoriesController(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        // Get all categories with their details
        [HttpGet]
        public async Task<ActionResult<List<CategoryReadDto>>> GetAllCategories()
        {
            var category_list = await _categoryService.GetAllAsync();
            return Ok(category_list);
        }

        // Get a category with its details
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReadDto>> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }

        // Add a category 
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CategoryReadDto>> CreateCategory(CategoryCreateDto createDto)
        {
            var createdCategory = await _categoryService.CreateOneAsync(createDto);
            return Ok(createdCategory);
        }
        
        // Update a category by its id
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryReadDto>> UpdateOneAsync([FromRoute] Guid id, [FromBody] CategoryUpdateDto updateDto)
        {
            await _categoryService.GetByIdAsync(id);
            await _categoryService.UpdateOneAsync(id, updateDto);
            var updatedCategory = await _categoryService.GetByIdAsync(id);
            return Ok(updatedCategory);
        }

        // Delete a category by its id
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneAsync([FromRoute] Guid id)
        {
            await _categoryService.DeleteOneAsync(id);
            return NoContent(); 
        }
    
    }
}
