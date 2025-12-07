using Demo1UserCurd.Models;
using Demo1UserCurd.Repository;
using Demo1UserCurd.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddCors(
    options =>
            {
                options.AddPolicy("*", policy =>
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

app.UseCors("*");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
