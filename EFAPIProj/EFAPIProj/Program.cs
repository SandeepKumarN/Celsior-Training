using EFAPIProj.Repositories;
using EFAPIProj.Interfaces;
using Microsoft.EntityFrameworkCore;
using EFAPIProj.Models;
using EFAPIProj.Properties.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ShoppingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<int, ProductImage>, ProductImageRepository>();
builder.Services.AddScoped<IRepository<int, Customer>, CustomerRepository>();



builder.Services.AddControllers();


builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
