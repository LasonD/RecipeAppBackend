using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using RecipesAppApiFull.Mapping;
using RecipesAppApiFull.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = builder.Configuration
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(config.GetConnectionString("ApplicationDbContextConnectionString")));

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
