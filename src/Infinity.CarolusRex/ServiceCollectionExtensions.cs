using Infinity.Carolus_Rex.Builders;
using Infinity.CarolusRex.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Infinity.CarolusRex;

public static class ServiceCollectionExtensions
{
    public static IQueryCompositeBuilder AddCompositeQuery<TQuery, TQueryContext>(this IServiceCollection services)
        where TQueryContext : IQueryContext, new()
    {
        // Transient?
        services.AddSingleton<CompositeQuery<TQuery, TQueryContext>>();

        var builder = new QueryCompositeBuilder<TQuery, TQueryContext>(services);

        return builder;
    }

    public static IQueryCompositeBuilder AddQueryHandler<TQueryHandler>(this IQueryCompositeBuilder builder)
        where TQueryHandler : class, IQueryHandler
    {
        var genericType = typeof(IQueryHandler<>).MakeGenericType(builder.Type);

        builder.Services.AddTransient(genericType, typeof(TQueryHandler));

        return builder;
    }
}
