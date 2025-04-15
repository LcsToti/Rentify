using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RentifyAPI.Models;
using RentifyAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();

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
// app.UseAuthentication();
// app.UseAuthorization();


// 6. Mapeamento de endpoints (controllers, minimal APIs, etc.)
app.MapControllers();

app.Run();