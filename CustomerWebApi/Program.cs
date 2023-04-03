using CustomerWebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

//DbContext injection
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword}";
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
