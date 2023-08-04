using Microsoft.Extensions.DependencyInjection;

namespace Infinity.CarolusRex.Queries;

internal class QueryChain<TQuery, TQueryResponse>
    where TQuery : IQuery<TQueryResponse>
{
    private readonly IServiceProvider serviceProvider;
    private readonly IEnumerable<Type> handlers;

    public QueryChain(
        IServiceProvider serviceProvider,
        IEnumerable<Type> handlers)
    {
        this.serviceProvider = serviceProvider;
        this.handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
    }

    public async ValueTask RunAsync(TQuery query, CancellationToken cancellationToken)
    {
        // Get query handlers from ServiceProvider
        var queryHandlers = serviceProvider.GetService<IQueryHandler<TQuery, TQueryResponse>>();


        foreach (var handler in handlers)
        {
            // Get handler from serviceProvider
            var h = serviceProvider.GetService(handler) as IQueryHandler<TQuery, TQueryResponse>;

            // Run decorators and handler
            await h.Handle(query, cancellationToken);
        }
    }
}
