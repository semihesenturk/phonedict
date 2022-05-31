using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Report.Application.Extensions;

public static class Registration
{
    public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddMediatR(assm);
        services.AddAutoMapper(assm);

        return services;
    }
}
