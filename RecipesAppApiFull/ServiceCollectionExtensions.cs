using Domain.Interfaces;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repository;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

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
            var identityBuilder = services.AddIdentityCore<RecipesAppIdentityUser>();
            identityBuilder.AddEntityFrameworkStores<RecipesAppIdentityDbContext>();

            return services;
        }
    }
}
