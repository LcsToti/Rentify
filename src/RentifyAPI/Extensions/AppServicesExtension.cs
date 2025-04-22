using RentifyAPI.Repositories;
using RentifyAPI.Services.Auth;
using RentifyAPI.Services.Password;
using RentifyAPI.Services.Token;
using RentifyAPI.Services.UserServices;

namespace RentifyAPI.Extensions;

public static class AppServicesExtension
{
    public static void AddAppServices(this IServiceCollection services)
    {

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<ITokenService, TokenService>();
    }

}
