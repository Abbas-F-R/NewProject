using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
namespace dotnet.Extensions;

public static class ApplicationSecurityExtension
{
    public static IServiceCollection AddSecurityExtension(this IServiceCollection services, IConfiguration config)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
        services.AddAuthentication()
            .AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                // ValidIssuer = builder.Configuration["Jwt:Issuer"], 
                ValidateLifetime = true,
                ValidateAudience = false,
                // ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    config.GetSection("AppSettings:Token").Value!))
            };
        });

        return services;
    }
}