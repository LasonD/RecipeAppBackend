using MediatR;
using RecipesAppApiFull;
using RecipesAppApiFull.Mapping;
using RecipesAppApiFull.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = builder.Configuration
    .AddJsonFile("appsettings.json")
    .Build();

var services = builder.Services;

services.AddControllers()
    .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
services.AddEndpointsApiExplorer();
services.AddConfiguredSwaggerGen();
services.AddAutoMapper(typeof(MappingProfile));
services.AddMediatR(typeof(Program));
services.AddConfiguredDataAccess(config);
services.AddConfiguredIdentity();
services.AddConfiguredJwtBearer(config);
services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(p => p
    .SetIsOriginAllowed(origin => origin == config["Jwt:ValidAudience"])
    .AllowAnyHeader());

app.UseAuthorization();
app.UseAuthentication();

app.UseMiddleware<UserIdExtractor>();

app.MapControllers();

app.Run();
