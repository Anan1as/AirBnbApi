using AirBnbApi.Models;
using AirBnbApi.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configuración del servicio de MongoDB
builder.Services.Configure<UserDatabaseSettings>(
    builder.Configuration.GetSection("UserDatabase"));

builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<HousesService>();
builder.Services.AddSingleton<ContractsService>();

// Configuración de controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AirBnbApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();