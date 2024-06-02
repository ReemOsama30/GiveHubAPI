using Microsoft.EntityFrameworkCore;

using Clean_Architecture.Infrastructure.DbContext;

using Clean_Architecture.Application.Mapper;
using Clean_Architecture.Infrastructure.Repositories;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Application.Interfaces;
using charityPulse.core.Models;
using Clean_Architecture.Application.services;

namespace Clean_Architecture.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          
            builder.Services.AddAutoMapper(typeof(MappingProfile));
         
            builder.Services.AddDbContext<ApplicationDbContext>(Options => {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();  
            builder.Services.AddScoped<IRepository<Project>,Repository<Project>>();
            builder.Services.AddScoped<projectService>();
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
        }
    }
}
