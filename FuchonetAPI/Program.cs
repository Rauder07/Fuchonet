//1. Using to Work with EntityFramework
using FuchonetAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;


var builder = WebApplication.CreateBuilder(args);

//2. Connection with SQL SERVER 

const string ConnectionName = "ConecctionSQL";
//obtener la cadena de conexion de el appsettings.jon
var ConnectionString = builder.Configuration.GetConnectionString(ConnectionName);

//3 TODO: Add Context
builder.Services.AddDbContext<FuchonetDbContext>(options => options.UseSqlServer(ConnectionString));

// Add services to the container.

builder.Services.AddControllers();
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

//scafolt
//Scaffold - DbContext "data source=DESKTOP-Q028E7G\SQLEXPRESS;initial catalog=FUCHONET;user id=rauder;password=153; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models - ContextDir DataAccess - Context FuchonetDbContext