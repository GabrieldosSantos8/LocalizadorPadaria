using LocalizadorPadaria.Api.Data;
using LocalizadorPadaria.Api.Services;
using Microsoft.EntityFrameworkCore;
using LocalizadorPadaria.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura SQLite
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=padarias.db"));

// Configura o HttpClient e o Service
builder.Services.AddHttpClient<IViaCepService, ViaCepService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();