using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrera API-controllers
builder.Services.AddControllers();


// DbContext med SQLite
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

app.UseHttpsRedirection();

// Aktiverar controllers
app.MapControllers();

app.Run();