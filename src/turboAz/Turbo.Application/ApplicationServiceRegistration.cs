using System.Reflection;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using Core.Mailing;
using Core.Mailing.MailkitImplementations;
using Core.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Turbo.Application.Features.Brands.Rules;
using Turbo.Application.Services.AuthService;

namespace Turbo.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<BrandRules>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

        services.AddTransient<IAuthService, AuthService>();
        
        services.AddTransient<ITokenHelper, JwtHelper>();

        services.AddSingleton<IMailService, MailkitMailService>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}