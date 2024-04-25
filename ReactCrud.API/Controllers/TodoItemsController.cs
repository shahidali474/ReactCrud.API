using Microsoft.AspNetCore.Mvc;
using ReactCrud.Core.Dtos;
using ReactCrud.Core.Extensions;
using ReactCrud.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoRepository _todoItemRepository;

        public TodoItemController(ITodoRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetAllTodoItems()
        {
            var todoItems = await _todoItemRepository.GetAll();
            var todoItemDtos = todoItems.Select(todoItem => todoItem.MapToDto());
            return Ok(todoItemDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItemById(int id)
        {
            var todoItem = await _todoItemRepository.GetById(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem.MapToDto());
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> CreateTodoItem(TodoItemDto todoItemDto)
        {
            var todoItem = todoItemDto.MapToModel();
            await _todoItemRepository.Add(todoItem);
            return CreatedAtAction(nameof(GetTodoItemById), new { id = todoItem.Id }, todoItem.MapToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, TodoItemDto todoItemDto)
        {
            if (id != todoItemDto.Id)
            {
                return BadRequest("TodoItem ID mismatch");
            }

            try
            {
                var existingTodoItem = await _todoItemRepository.GetById(id);
                if (existingTodoItem == null)
                {
                    return NotFound();
                }

                // Update other properties as needed

                await _todoItemRepository.Update(existingTodoItem);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the todo item.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(int id)
        {
            var existingTodoItem = await _todoItemRepository.GetById(id);
            if (existingTodoItem == null)
            {
                return NotFound();
            }

            await _todoItemRepository.Delete(id);

            return NoContent();
        }
    }


}
