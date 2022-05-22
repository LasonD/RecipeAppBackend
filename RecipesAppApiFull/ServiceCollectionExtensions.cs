using System.Text;
using Domain.Interfaces;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repository;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace RecipesAppApiFull
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguredDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContextConnectionString")));

            services.AddDbContext<RecipesAppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContextConnectionString")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IIngredientsRepository, IngredientRepository>();

            return services;
        }

        public static IServiceCollection AddConfiguredIdentity(this IServiceCollection services)
        {
            var identityBuilder = services.AddIdentityCore<AppIdentityUser>();
            identityBuilder.AddEntityFrameworkStores<RecipesAppIdentityDbContext>();

            return services;
        }

        public static IServiceCollection AddConfiguredJwtBearer(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtSettings = new JwtSettings(config);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.ValidIssuer,
                        ValidAudience = jwtSettings.ValidAudience,
                        IssuerSigningKey = jwtSettings.SecurityKey
                    };
                });

            services.AddTransient<IJwtGenerator, JwtGenerator>();

            return services;
        }
    }
}
