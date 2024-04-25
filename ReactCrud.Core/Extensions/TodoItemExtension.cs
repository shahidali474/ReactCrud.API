using ReactCrud.Core.Dtos;
using ReactCrud.Data.Models;

namespace ReactCrud.Core.Extensions
{
    public static class TodoItemExtension
    {
        public static TodoItemDto MapToDto(this TodoItem todoItem)
        {
            return new TodoItemDto
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete,
            };
        }

        public static TodoItem MapToModel(this TodoItemDto todoItemDto)
        {
            return new TodoItem
            {
                Id = todoItemDto.Id,
                Name = todoItemDto.Name,
                IsComplete = todoItemDto.IsComplete
            };
        }
    }
}
