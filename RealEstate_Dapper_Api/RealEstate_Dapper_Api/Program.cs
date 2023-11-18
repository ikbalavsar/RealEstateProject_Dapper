using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Models.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Models.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Models.Repositories.PopularLocationRepository;
using RealEstate_Dapper_Api.Models.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Models.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Models.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Models.Repositories.WhoWeAreRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Registrationlarýmýzý gerçekleþtiriyoruz.

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();


//
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
