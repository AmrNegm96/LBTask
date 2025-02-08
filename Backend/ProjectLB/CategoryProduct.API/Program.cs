using CategoryProduct.API.Seeder;
using CategoryProduct.Application.Contracts;
using CategoryProduct.Application.Mappers;
using CategoryProduct.Application.Services;
using CategoryProduct.Application.Strategies;
using CategoryProduct.Domain.Contracts;
using CategoryProduct.Infrastructure.Context;
using CategoryProduct.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region Injection
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ProductMapper>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<CategoryMapper>();

builder.Services.AddScoped<IProductPricingService, ProductPricingServiceDecorator>();

//i should register the decorators here

// Default Pricing Strategy (Standard)
builder.Services.AddScoped<IPricingStrategy, StandardPricingStrategy>();
builder.Services.AddScoped<ProductPricingServiceStrategy>();

#endregion

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFront",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
#endregion





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Seeder.SeedData(builder.Services.BuildServiceProvider()).GetAwaiter().GetResult();


var app = builder.Build();

app.UseExceptionHandler(appBuilder =>
{
    appBuilder.Run(async context =>
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;

        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "An error occurred. Please try again later."
        };

        await context.Response.WriteAsJsonAsync(response);
    });
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFront");

app.UseAuthorization();

app.MapControllers();

app.Run();
