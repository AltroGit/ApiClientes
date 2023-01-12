using ApiClientes.DataAccess.Base;
using ApiClientes.DataAccess.Contracts.Base;
using ApiClientes.Infrastructure;
using ApiClientes.Services;
using ApiClientes.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// DependencyInyection
DependencyInyection.ConfigureDependencyInjection(builder.Services);
ServiceCollectionServiceExtensions.AddScoped<ICustomerService, CustomerService>(builder.Services);
ServiceCollectionServiceExtensions.AddScoped(builder.Services, typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>));

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



