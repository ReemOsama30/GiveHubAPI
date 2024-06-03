using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.Application.Mapper;
using Clean_Architecture.Application.services;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Clean_Architecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;





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
https://github.com/ReemOsama30/charityPulse/pull/17/conflict?name=Clean%2BArchitecture.APIs%252FProgram.cs&ancestor_oid=96f42df9f30310bc851aaa38be458841057fd71a&base_oid=3f445db0d6b35668b710190f8789342c89dfc8ea&head_oid=6b37adc6570c3237bde19cc0b3612293e5010d07
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddDbContext<ApplicationDbContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IRepository<Project>, Repository<Project>>();
            builder.Services.AddScoped<IRepository<Charity>, Repository<Charity>>();
            builder.Services.AddScoped<projectService>();
            builder.Services.AddScoped<charityService>();

            builder.Services.AddScoped<DonationReportService>();
            builder.Services.AddScoped<IDonationReportRepository, DonationReportRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();         
            builder.Services.AddScoped<ReviewService>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();  
            builder.Services.AddScoped<IRepository<Project>,Repository<Project>>();
            builder.Services.AddScoped<IRepository<Advertisment>, Repository<Advertisment>>();

            builder.Services.AddScoped<projectService>();

            builder.Services.AddScoped<corporateService>();
            builder.Services.AddScoped<IRepository<Corporate>,Repository<Corporate>>();

            builder.Services.AddScoped<AdvertismentService>();



            // ------------------------------------------------------------
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This�is�to�generate�the�Default�UI�of�Swagger�Documentation����
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Charity Pulse",
                    Description = " ITI Projrcy"
                });
                //�To�Enable�authorization�using�Swagger�(JWT)����
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter�'Bearer'�[space]�and�then�your�valid�token�in�the�text�input�below.\r\n\r\nExample:�\"Bearer�eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    }
                    },
                    new string[] {}
                    }
                    });
            });
            //---------------------------------------------------------------
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
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

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
