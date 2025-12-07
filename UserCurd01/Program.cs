
using Microsoft.EntityFrameworkCore;
using UserCurd01.Models;
using UserCurd01.Repository;
using UserCurd01.Services;

namespace UserCurd01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<UserDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserServices, UserServices>();


            builder.Services.AddCors(option => 
            option.AddPolicy("*", policy => 
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


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
        }
    }
}
