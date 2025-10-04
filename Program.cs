using Microsoft.EntityFrameworkCore;
using ViajesAPI.Models;
using ViajesAPI.Repositories.Interfaces;
using ViajesAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ViajesContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Agregar inyección de dependencias
builder.Services.AddScoped<IViajeRepository, IViajeRepository>();
builder.Services.AddScoped<IViajeService, IViajeService>();

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
