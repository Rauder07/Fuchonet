//1. Using to Work with EntityFramework
<<<<<<< Updated upstream
using FuchonetAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

=======
using Fuchonet.Repositories;
using Fuchonet.Persistence;
using Fuchonet.FuchonetAPI.Paginator;
using Fuchonet.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;
using Fuchonet.Services.Interface;
using Fuchonet.Services.Implementation;
>>>>>>> Stashed changes

var builder = WebApplication.CreateBuilder(args);

//2. Connection with SQL SERVER 

const string ConnectionName = "ConecctionSQL";
//obtener la cadena de conexion de el appsettings.jon
var ConnectionString = builder.Configuration.GetConnectionString(ConnectionName);

//3 TODO: Add Context
builder.Services.AddDbContext<FuchonetDbContext>(options => options.UseSqlServer(ConnectionString));
<<<<<<< Updated upstream

=======
builder.Services.RegisterMapsterConfiguration();
builder.Services.AddScoped<IPagedList, PagedList>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
builder.Services.AddScoped<IServiceAgrementService, ServiceAgrementService>();


builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
>>>>>>> Stashed changes
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