using Microsoft.EntityFrameworkCore;
using UserBackendProject.Models;
using UserBackendProject.Repository;   
using UserBackendProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();

builder.Services.AddDbContext<UserDbContext>(option =>
    option.UseSqlServer(config.GetConnectionString("DbCon")));

// Register Repository and Service
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserServices>();

// Add CORS
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");   // ✅ Use CORS here
app.UseAuthorization();
app.MapControllers();
app.Run();
