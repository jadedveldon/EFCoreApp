using EDCore.Data.Entities.Modals;
using EFCoreApp.DataLayer.Implementations;
using EFCoreApp.DataLayer.Interfaces;
using EFCoreApp.Repository.Implementations;
using EFCoreApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeOperationsDL, EmployeeOperationsDL>();
builder.Services.AddScoped(typeof(IGenericsRepo<>), typeof(GenericsRepo<>));
builder.Services.AddScoped<IDepartmentOperationsDL, DepartmentOperationsDL>();
builder.Services.AddDbContext<MasterContext>(options => options.UseSqlServer("Data Source = TL545; Integrated Security = True"));
builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddDbContext<LinqdemoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

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
