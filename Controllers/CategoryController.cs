using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nzwalks.API.CustomActionFilters;
using toDoList.Dtos;
using toDoList.Interfaces;
using toDoList.Model;

namespace toDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

       
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

       
        [HttpPost]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            
            var categoryModel=  _mapper.Map<CategoryDto>(createCategoryDto);
            var createdCategory = await _categoryService.CreateAsync(categoryModel);
      
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut ("{id}")]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
           
            var updatedCategory = await _categoryService.UpdateAsync(id,categoryDto);
            if (updatedCategory == null) return NotFound();
            return Ok(updatedCategory);
        }

      
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var deletedCategory = await _categoryService.DeleteAsync(id);
            if (deletedCategory == null) return NotFound();
            return Ok(deletedCategory);
        }
    }
}
