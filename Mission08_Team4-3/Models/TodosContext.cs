using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team4_3.Models
{
    public partial class TodosContext : DbContext
    {
        public TodosContext(DbContextOptions<TodosContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
