using Microsoft.OpenApi.Models;

namespace RentifyAPI.Extensions;

public static class SwaggerExtension
{
    public static void AddSwaggerSetup(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v0.1.0", new OpenApiInfo { Title = "RentifyAPI", Version = "v0.1.0", Description = "API in development stage." });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header usando o esquema Bearer. Ex: 'Bearer {seu_token}'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    Array.Empty<string>()
                }
            });
        });
    }
}