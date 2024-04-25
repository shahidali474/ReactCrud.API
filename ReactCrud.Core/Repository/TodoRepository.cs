using Microsoft.EntityFrameworkCore;
using ReactCrud.Core.Interface;
using ReactCrud.Data;
using ReactCrud.Data.Models;

namespace ReactCrud.Core.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ReactCrudContext _context;

        public TodoRepository(ReactCrudContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetById(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task Add(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TodoItem todoItem)
        {
            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem != null)
            {
                _context.TodoItems.Remove(todoItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
