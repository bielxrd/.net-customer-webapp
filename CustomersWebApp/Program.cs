using customers_api.Infra.Repositories;
using CustomersWebApp.Application.Interfaces;
using CustomersWebApp.Application.UseCases.CustomerUseCases;
using CustomersWebApp.Domain.Interfaces;
using CustomersWebApp.Infra.Data;
using CustomersWebApp.Infra.Middleware;
using CustomersWebApp.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer API", Version = "v1" });
});

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();

builder.Services.AddScoped<ICreateCustomerUseCase, CreateCustomerUseCase>();
builder.Services.AddScoped<IGetCustomersUseCase, GetCustomersUseCase>();
builder.Services.AddScoped<IGetCustomerDetailsUseCase, GetCustomerDetailsUseCase>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
