using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Turbo.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }
}