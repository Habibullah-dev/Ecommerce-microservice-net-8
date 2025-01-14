using System.Reflection;
using Asp.Versioning;
using Catalog.Core.Repositories.Interfaces;
using Catalog.Infrastructure.Data;
using Catalog.Application.Handlers;
using Catalog.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddApiVersioning(cfg => {
    cfg.DefaultApiVersion = new ApiVersion(1, 0);
    cfg.AssumeDefaultVersionWhenUnspecified = true;
    cfg.ReportApiVersions = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>  {
    c.SwaggerDoc("v1", 
    new Microsoft.OpenApi.Models.OpenApiInfo {
       Title = "Catalog.API",
       Version = "v1"
    });
});

//Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);


var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
var applicationAssembly = Directory.GetFiles(path, "Application.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();

//Register MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
  //  cfg.RegisterServicesFromAssembly(typeof(GetAllBrandsHandler).Assembly);
    cfg..RegisterServicesFromAssembly(applicationAssembly);
});

//Register Application Service
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBrandRepository, ProductRepository>();
builder.Services.AddScoped<ITypeRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();