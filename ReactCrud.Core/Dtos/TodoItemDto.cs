using ReactCrud.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCrud.Core.Dtos
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
