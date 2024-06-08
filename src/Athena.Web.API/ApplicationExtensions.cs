using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationExtensions
{
    public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
    {
        Assembly assembly = Assembly.Load("Athena.Application");

        builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

        builder.Services.AddMediator(assembly);

        return builder;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly)
    {
        return services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
    }
}