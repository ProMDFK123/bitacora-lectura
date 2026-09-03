using Bitacora_API.Application.Interfaces;
using Bitacora_API.Application.Services;
using Bitacora_API.Infrastructure.Persistence;
using Bitacora_API.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();

// Entity Framework Core + PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Repositories
builder.Services.AddScoped<IObraRepository, ObraRepository>();

// Services
builder.Services.AddScoped<IObraService, ObraService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();