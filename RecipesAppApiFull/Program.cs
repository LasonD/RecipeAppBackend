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
services.AddSwaggerGen();
services.AddAutoMapper(typeof(MappingProfile));
services.AddMediatR(typeof(Program));
services.AddConfiguredDataAccess(config);
services.AddConfiguredIdentity();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
