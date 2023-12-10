using BLL.Interfaces;
using BLL.Services;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApi.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов в контейнер.
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));

// DbContext
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger/OpenAPI
    app.UseSwagger();
    app.UseSwaggerUI();


    app.UseDefaultFiles();
    app.UseStaticFiles();

    app.UseHttpsRedirection();

    // Страница с отображением исключений
    app.UseDeveloperExceptionPage();
}

// Authorization
app.UseAuthorization();

// Controllers
app.MapControllers();

using var scope = app.Services.CreateScope();
var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
initializer.Initialize();

app.Run();