using Clivia.Application.Services;
using Clivia.Core.Repositories;
using Clivia.Core.Services;
using Clivia.Infrastructure.Data;
using Clivia.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura la conexión a la base de datos
builder.Services.AddDbContext<CliviaDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CliviaDBConnection")));

// Repositorios
builder.Services.AddScoped<IHabitacionRepository, HabitacionRepository>();

// Services
builder.Services.AddScoped<IHabitacionService, HabitacionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

