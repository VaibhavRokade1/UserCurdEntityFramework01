
using JwtAuthInASP.NetCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthInASP.NetCoreWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ProductDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
