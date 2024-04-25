using Microsoft.EntityFrameworkCore;
using ReactCrud.Data.Models;

namespace ReactCrud.Data;
public class ReactCrudContext : DbContext
{
    public ReactCrudContext(DbContextOptions<ReactCrudContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }
}
