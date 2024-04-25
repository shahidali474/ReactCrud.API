using ReactCrud.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCrud.Core.Interface
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAll();
        Task<TodoItem> GetById(int id);
        Task Add(TodoItem todoItem);
        Task Update(TodoItem todoItem);
        Task Delete(int id);
    }
}
