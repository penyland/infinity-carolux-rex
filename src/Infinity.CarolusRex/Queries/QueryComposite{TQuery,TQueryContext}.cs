using Microsoft.Extensions.DependencyInjection;

namespace Infinity.CarolusRex.Queries;

public class CompositeQuery<TQuery, TQueryContext>
    where TQueryContext : IQueryContext, new()
{
    private readonly IServiceProvider serviceProvider;

    public CompositeQuery(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task RunAsync(TQuery query, CancellationToken cancellationToken)
    {
        // Create context
        var context = new TQueryContext();

        // Get query handlers from ServiceProvider
        var queryHandlers = serviceProvider.GetService<IEnumerable<IQueryHandler<TQuery>>>();

        foreach (var handler in queryHandlers)
        {
            await handler.Handle(query, context, cancellationToken);
        }
    }
}
