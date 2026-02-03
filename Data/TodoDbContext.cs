using Microsoft.EntityFrameworkCore;

namespace TodoAPI.Data
{
    // Klass som sköter kontakten mellan applikationen och databasen
    public class TodoDbContext : DbContext
    {
        // Konstruktor som tar emot inställningar för databasen
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        // Representerar tabellen "Todos" i databasen
        public DbSet<TodoAPI.Models.TodoModel> Todos { get; set; } = default!;
    }
}