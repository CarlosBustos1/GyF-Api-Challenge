using FluentValidation.AspNetCore;
using GyF_Api.Challenge.Service;
using GyF_Api_Challenge.Data;
using GyF_Api_Challenge.Data.Interfaces;
using GyF_Api_Challenge.Extensions;
using GyF_Api_Challenge.MappingProfiles;
using GyF_Api_Challenge.Models;
using GyF_Api_Challenge.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyF_Api_Challenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<GyFContext>(setup => setup.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddAutoMapper(typeof(MappingProfile));
           // services.AddHostedService<SeedDataBaseWorker>();

            services.AddIdentityCore<IdentityUser>()
                .AddUserManager<UserManager<IdentityUser>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<GyFContext>();
            //services.AddLoggingCustom(Configuration);

            //services.AddControllers().AddFluentValidation(options =>
            //{
            //    options.RegisterValidatorsFromAssemblyContaining(typeof(UpdateClienteModelValidator));
            //});

            //services.AddAutoMapper(options => options.AddProfile<MappingProfile>());

            //services.AddDatabase(Configuration);

            //services.AddIdentity<IdentityUser,IdentityRole>()
            //.AddUserManager<UserManager<IdentityUser>>()
            //.AddDefaultTokenProviders()
            //.AddEntityFrameworkStores<GyFContext>();
            //services.AddIdentityCore<IdentityUser>()
            //    .AddUserManager<UserManager<IdentityUser>>()
            //    .AddDefaultTokenProviders()
            //    .AddEntityFrameworkStores<GyFContext>();

            services.AddScoped<ClienteService, ClienteService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GyF_Api_Challenge", Version = "v1" });
            });

            services.AddHostedService<InitializeDataBaseHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GyF_Api_Challenge v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
