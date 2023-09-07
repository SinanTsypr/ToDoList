
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;

namespace ToDoListApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(s => s.AddDefaultPolicy(p => p
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod()
                                                            .AllowAnyOrigin()));

            var con = builder.Configuration.GetConnectionString("ApplicationDbContext");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(con));

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

            app.UseCors(); //*****************************

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}