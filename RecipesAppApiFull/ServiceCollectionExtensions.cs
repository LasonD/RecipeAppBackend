using Infrastructure.DataAccess;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace RecipesAppApiFull
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguredDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContextConnectionString")));

            services.AddDbContext<RecipesAppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContextConnectionString")));

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
