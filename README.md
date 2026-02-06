# Todo API

Detta repository innehåller ett REST API byggt med ASP.NET Core och SQLite. API:et hanterar todos med full CRUD-funktionalitet och automatiska databasmigrationer.

## Länk

En liveversion av API:et finns tillgänglig på följande URL: **http://159.223.216.135/api/todo**

## Installation

API:et använder SQLite för datalagring. För att installera och köra lokalt:

* `git clone https://github.com/frja2400/TodoAPI.git`
* `cd TodoAPI`
* `dotnet restore`
* Starta servern: `dotnet run`

## Datamodell
```csharp
public class TodoModel
{
    public int Id { get; set; }
    
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    
    [StringLength(200)]
    public string? Description { get; set; }
    
    [Required]
    public string Status { get; set; } = "Ej påbörjad";
}
```

## Användning

| Metod     | Ändpunkt          | Beskrivning           |
|-----------|-------------------|-----------------------|
| GET       | `/api/todo`       | Hämtar alla todos     |
| GET       | `/api/todo/:id`   | Hämtar specifik todo  |
| POST      | `/api/todo`       | Lägger till ny todo   |
| PUT       | `/api/todo/:id`   | Uppdaterar todo       |
| DELETE    | `/api/todo/:id`   | Raderar todo          |

## Validering

API:et validerar inkommande data med Data Annotations:
* `Title` är obligatorisk och måste vara minst 3 tecken.
* `Description` är valfri med max 200 tecken.
* `Status` är obligatorisk med standardvärde "Ej påbörjad".

## CORS

API:et är konfigurerat med CORS för att tillåta kommunikation från frontend:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
```

## Publicering
```bash
dotnet publish -c Release -o ./publish
```

Kopiera sedan `publish`-mappen till din server.