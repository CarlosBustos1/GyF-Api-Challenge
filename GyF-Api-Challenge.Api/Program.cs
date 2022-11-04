using FluentValidation.AspNetCore;
using GyF_Api_Challenge.Api.MappingProfiles;
using GyF_Api_Challenge.Api.Extensions;
using GyF_Api_Challenge.Validators;
using Microsoft.AspNetCore.Identity;
using GyF_Api_Challenge.Data;
using GyF_Api_Challenge.Api;
using GyF_Api_Challenge.Data.Interfaces;
using GyF_Api.Challenge.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using GyF_Api_Challenge.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddAutoMapper(options => options.AddProfile<MappingProfile>());

builder.Services.AddControllers().AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<CreateClienteModelValidator>());

builder.Services.AddHostedService<InitializeDataBaseHostedService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<AuthManager>();
builder.Services.AddIdentityCustomized();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.SaveToken = false;
    o.RequireHttpsMetadata = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerCustomized();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
