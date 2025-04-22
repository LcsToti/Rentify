using Microsoft.EntityFrameworkCore;
using RentifyAPI.Models;

namespace RentifyAPI.Extensions;

public static class DbExtension
{
    public static void AddDbExt(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<RentifyContext>(options =>
            options.UseMySql(
                config.GetConnectionString("Rentify"),
                new MySqlServerVersion(new Version(8, 0, 41))
            )
        );
    }
}
