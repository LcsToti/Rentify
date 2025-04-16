using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RentifyAPI.Models;
using RentifyAPI.Services.Auth;
using RentifyAPI.Services.UserServices;
using System.Text;
using RentifyAPI;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<TokenService>();

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDbContext<RentifyContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("HabitumContext"),
        new MySqlServerVersion(new Version(8, 0, 41))
    )
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalSwagger", policy =>
        policy.WithOrigins("http://localhost:8081")
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RentifyAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header usando o esquema Bearer. Ex: 'Bearer {seu_token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RoleClaimType = ClaimTypes.Role
    };
});

var app = builder.Build();

// Pipeline e middlewares

// 1. Tratamento de erros
app.UseCors("AllowLocalSwagger");
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentifyAPI v1");
    });
}

// 2. Redirecionamento HTTPS
app.UseHttpsRedirection();

// 3. Middleware de arquivos estáticos (se usados)
app.UseStaticFiles();

// 4. Roteamento
app.UseRouting();

// 5. Autenticação/autorização (se aplicável)
app.UseAuthentication();
app.UseAuthorization();


// 6. Mapeamento de endpoints (controllers, minimal APIs, etc.)
app.MapControllers();

app.Run();