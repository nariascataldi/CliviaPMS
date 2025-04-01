using Clivia.Application.Services; // Necesario para HabitacionService
using Clivia.Core.Repositories;    // Necesario para IHabitacionRepository
using Clivia.Core.Services;       // Necesario para IHabitacionService
using Clivia.Infrastructure.Data; // Necesario para CliviaDbContext
using Clivia.Infrastructure.Repositories; // Necesario para HabitacionRepository
using Microsoft.EntityFrameworkCore;

// Necesario para Assembly.Load

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Variables de Entorno
builder.Configuration.AddEnvironmentVariables();

// Configura la conexión a la base de datos
builder.Services.AddDbContext<CliviaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CliviaDBConnection")));

// --- Configuración de AutoMapper ---
builder.Services.AddAutoMapper(typeof(HabitacionService).Assembly);

// --- Inyección de Dependencias ---
// Repositorios
builder.Services.AddScoped<IHabitacionRepository, HabitacionRepository>();
// Services
builder.Services.AddScoped<IHabitacionService, HabitacionService>();
// ... Aquí añadirás más repositorios y servicios (IReservaRepository, etc.)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Asegúrate de que esta línea esté después de UseAuthorization si usas atributos [Authorize]

app.Run();