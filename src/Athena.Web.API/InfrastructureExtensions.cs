using Athena.Domain;
using Athena.Domain.Categories;
using Athena.Infrastructure;
using Athena.Infrastructure.Categories;

using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureExtensions
{
    public static IHostApplicationBuilder AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        builder.AddEntityFrameworkDbContexts();

        builder.Services.AddRepositories();
        builder.Services.AddUnitOfWork();

        return builder;
    }

    private static void AddEntityFrameworkDbContexts(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<AthenaContext>("postgresdb");
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<ICategoryRepository, CategoryRepository>();
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}