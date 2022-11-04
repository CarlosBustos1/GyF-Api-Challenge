
using GyF_Api_Challenge.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;

namespace GyF_Api_Challenge.Api.Extensions
{
    public static class ServiceCollectionExtentesions
    {

        public static void AddAuthenticationCustom(this ServiceProvider services)
        {

        }

        public static void AddLoggingstom(this IServiceCollection services, IConfiguration configuration)
        {
            var log = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console()
                .Enrich.FromLogContext()
                .CreateLogger();



        }

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<GyFContext>(options => options.UseInMemoryDatabase("GyF-Challenge-DB"));
        }

        public static void AddIdentityCustomized(this IServiceCollection services)
        {
            services.AddIdentityCore<IdentityUser>(q =>
                {
                    q.User.RequireUniqueEmail = false;
                    q.Password.RequiredLength = 6;
                    q.Password.RequireNonAlphanumeric = false;
                    q.Password.RequireUppercase = false;
                    q.Password.RequireLowercase = false;
                    q.Password.RequireDigit = false;
                

                })
            .AddUserManager<UserManager<IdentityUser>>()
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<GyFContext>();

        }

        public static void AddSwaggerCustomized(this IServiceCollection services)
        {
            services.AddSwaggerGen(o =>
            {
                o.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });

                o.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                           new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
                            },
                            new string[] {}
                        }
                    });
            });
        }
    }
}
