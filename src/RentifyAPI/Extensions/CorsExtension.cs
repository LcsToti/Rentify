namespace RentifyAPI.Extensions;

public static class CorsExtension
{
    public static void AddCustomCors(this IServiceCollection services)
    {

        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalSwagger", policy =>
                policy.WithOrigins("http://localhost:8081")
                  .AllowAnyMethod()
                  .AllowAnyHeader());
            options.AddPolicy("AllowProductionClients", policy =>
                policy.WithOrigins("https://meusite.com", "https://appcliente.com")
                  .AllowAnyMethod()
                  .AllowAnyHeader());
        });
    }
}
