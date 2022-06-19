using Domain.Interfaces;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repository;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace RecipesAppApiFull
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguredDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContextConnectionString")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IIngredientsRepository, IngredientRepository>();

            return services;
        }

        public static IServiceCollection AddConfiguredIdentity(this IServiceCollection services)
        {
            services
                .AddIdentityCore<AppIdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection AddConfiguredJwtBearer(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddAuthorization(options =>
                {
                    options.DefaultPolicy = new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .Build();
                })
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    var jwtSettings = new JwtSettings(config);

                    options.Audience = jwtSettings.ValidAudience;
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

        public static IServiceCollection AddConfiguredSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Recipes App Api",
                    Version = "v1"
                });
                o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                o.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }
    }
}
