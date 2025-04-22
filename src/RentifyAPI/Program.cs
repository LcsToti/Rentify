using RentifyAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAppServices();
builder.Services.AddJwtAuth(builder.Environment);
builder.Services.AddCustomCors();
builder.Services.AddDbExt(builder.Configuration);
builder.Services.AddRateLimiting();
builder.Services.AddSwaggerSetup();


var app = builder.Build();

// Middlewares Pipeline

// 1. Errors handler
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowLocalSwagger");
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v0.1.0/swagger.json", "RentifyAPI v0.1.0");
        options.RoutePrefix = string.Empty;
    });
}
else if (app.Environment.IsProduction())
{
    app.UseCors("AllowProductionClients");
}

// 2. HTTPS Redirection
app.UseHttpsRedirection();

// 3. wwwroot for static files
// app.UseStaticFiles();

// 4. Routing
app.UseRouting();

// 5. Auth
app.UseAuthentication();
app.UseAuthorization();

// 6. RateLimiter
app.UseRateLimiter();

// 7. Endpoints Mapping (controllers, minimal APIs, etc.)
app.MapControllers();

app.Run();