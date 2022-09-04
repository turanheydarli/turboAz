using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Turbo.Application.Services.Repositories;
using Turbo.Persistence.Contexts;
using Turbo.Persistence.Repositories;

namespace Turbo.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
        {
            options.UseNpgsql(
                    configuration.GetConnectionString("PgSql")
                    ?? throw new NullReferenceException("Assign connection string in appsettings.json"))
                .EnableSensitiveDataLogging();
        });

        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}