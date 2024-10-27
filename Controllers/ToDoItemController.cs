using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nzwalks.API.CustomActionFilters;
using toDoList.Dtos;
using toDoList.Interfaces;
using toDoList.Model;

namespace toDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;
        private readonly IMapper _mapper;

        public ToDoItemController(IToDoItemService toDoItemService, IMapper mapper)
        {
            _toDoItemService = toDoItemService;
            _mapper = mapper;
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _toDoItemService.GetAllAsync();
            var itemsDtos=  _mapper.Map<List<ToDoItemDto>>(items);
            return Ok(itemsDtos);
        }

       
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _toDoItemService.GetByIdAsync(id);
            if (item == null) return NotFound();
            var itemsDtos = _mapper.Map<ToDoItemDto>(item);
            return Ok(itemsDtos);
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateToDoItemDto toDoItemDto)
        {
            var createdItem = await _toDoItemService.CreateAsync(toDoItemDto);
            if (createdItem == null) return NotFound();
            var createdDtos= _mapper.Map<ToDoItemDto>(createdItem);
            return CreatedAtAction(nameof(GetById), new { id = createdDtos.Id }, new
            {
                message = $"{createdDtos.Id} Saved Successfully",
                data = createdDtos
            });
        }

       
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id ,[FromBody]UpdateToDoItemDto toDoItemDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
           
            var updatedItem = await _toDoItemService.UpdateAsync(id, toDoItemDto);
            if (updatedItem == null) return NotFound();
            var updateDto= _mapper.Map<ToDoItemDto>(updatedItem);
            return Ok(new { message = $"Id-{updateDto.Id} Updated Successfully", data = updateDto });
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var deletedItem = await _toDoItemService.DeleteAsync(id);
            if (deletedItem == null) return NotFound();
            var deleteDto= _mapper.Map<ToDoItemDto>(deletedItem);
            return Ok(new {message=$"{deleteDto.Id} Deleted Successfully", data= deleteDto});
        }
    }
}
