using Microsoft.AspNetCore.RateLimiting;

namespace RentifyAPI.Extensions
{
    public static class RateLimitExtension
    {
        public static void AddRateLimiting(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("default", opt =>
                {
                    opt.Window = TimeSpan.FromMinutes(1);
                    opt.PermitLimit = 100;
                });

                options.AddFixedWindowLimiter("strict", opt =>
                {
                    opt.Window = TimeSpan.FromMinutes(1);
                    opt.PermitLimit = 10;
                });
            });
        }
    }
}
