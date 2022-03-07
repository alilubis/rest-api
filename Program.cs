using Microsoft.EntityFrameworkCore;
using RestAPI.Entities.DBContext;
using RestAPI.Interfaces;
using RestAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BusMealDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BusMealConnection"));
});
builder.Services.AddSingleton<IMemoryStuffsRepository, MemoryStuffsRepository>();
builder.Services.AddTransient<DepartmentRepository>(); 
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
