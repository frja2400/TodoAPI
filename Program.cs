using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrera API-controllers
builder.Services.AddControllers();

// DbContext med SQLite
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Konfigurera CORS för att tillåta alla origins, metoder och headers
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()      // Tillåt alla origins
              .AllowAnyMethod()       // Tillåt GET, POST, PUT, DELETE
              .AllowAnyHeader();      // Tillåt alla headers
    });
});

var app = builder.Build();

// Automatisk "dotnet ef database update" varje gång API:et startar
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TodoDbContext>();
        context.Database.Migrate(); // Kör migrations automatiskt
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ett fel uppstod vid migration av databasen.");
    }
}


// Aktivera CORS
app.UseCors("AllowAll");

app.UseAuthorization();

// Aktivera controllers
app.MapControllers();

app.Run();