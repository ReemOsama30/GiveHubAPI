using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.Application.Mapper;
using Clean_Architecture.Application.services;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Clean_Architecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using YourNamespace.Clients;





namespace Clean_Architecture.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Add services to the container.
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddDbContext<ApplicationDbContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            // Configure Identity services

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IRepository<Project>, Repository<Project>>();
            builder.Services.AddScoped<IRepository<Badge>, Repository<Badge>>();
            builder.Services.AddScoped<IRepository<AwardedBadge>, Repository<AwardedBadge>>();
            builder.Services.AddScoped<IRepository<Charity>, Repository<Charity>>();
            builder.Services.AddScoped<projectService>();
            builder.Services.AddScoped<charityService>();

            builder.Services.AddScoped<BadgeService>();
            builder.Services.AddScoped<SharedBadgeUtilityService>();


            builder.Services.AddScoped<DonationReportService>();
            builder.Services.AddScoped<IDonationReportRepository, DonationReportRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<ReviewService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IRepository<Project>, Repository<Project>>();
            builder.Services.AddScoped<IRepository<Advertisment>, Repository<Advertisment>>();

            builder.Services.AddScoped<projectService>();

            builder.Services.AddScoped<corporateService>();
            builder.Services.AddScoped<IRepository<Corporate>, Repository<Corporate>>();

            builder.Services.AddScoped<AdvertismentService>();
            builder.Services.AddScoped<DonorService>();
            builder.Services.AddScoped<IDonorRepository, DonorRepository>();
            builder.Services.AddScoped<AwardedBadgeService>();

            builder.Services.AddScoped<AccountService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();



            builder.Services.AddScoped<IMoneyDonationRepository, MoneyDonationRepository>();
            builder.Services.AddScoped<MoneyDonationService>();

            builder.Services.AddScoped<IInkindDonationRepository, InkindDonationRepository>();
            builder.Services.AddScoped<InKindDonationService>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<UserServices>();


            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder.SetIsOriginAllowed(alow => true)
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
                    });

            });
                builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIss"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAud"],
                    IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecritKey"]))
                };
            });
            // -----------------------------Swagger Part---------------------------- -/

            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GiveHub",
                    Description = " ITI Projrcy"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
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

            //paypal setting

            builder.Services.AddSingleton(
                x => new PaypalClient(

                    builder.Configuration["paypalOptions:clientID"],
                     builder.Configuration["paypalOptions:ClientSecretKey"],
                      builder.Configuration["paypalOptions:Mode"]
                    )


            );





            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
      
            app.UseAuthorization();
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}