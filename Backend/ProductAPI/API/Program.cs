using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Concrete;
using Service.Abstract;
using Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlConnection")
));


builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();


// Add services to the container.
builder.Services.AddControllers();
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
