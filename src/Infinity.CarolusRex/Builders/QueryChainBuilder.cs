using Infinity.CarolusRex.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Infinity.Carolus_Rex.Builders;

public interface IQueryCompositeBuilder
{
    IServiceCollection Services { get; }

    Type Type { get; }

    string Name { get; }
}

public class QueryCompositeBuilder<TQuery, TQueryContext> : IQueryCompositeBuilder
    where TQueryContext : IQueryContext, new()
{
    public QueryCompositeBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }

    public Type Type => typeof(TQuery);

    public string Name => typeof(TQuery).Name;
}

//internal class QueryChainBuilder<TQuery, TQueryResponse>
//    where TQuery : IQuery<TQueryResponse>
//    //where TQueryHandler : IQueryHandler<TQuery, TQueryResponse>
//{
//    private readonly List<IQueryHandler<TQuery, TQueryResponse>> handlers = new();
//    private readonly List<Type> chain = new();

//    public QueryChainBuilder<TQuery, TQueryResponse> AddQueryHandler<TQueryHandler>()
//        where TQueryHandler : IQueryHandler<TQuery, TQueryResponse>
//    {
//        chain.Add(typeof(TQueryHandler));
//        return this;
//    }

//    public QueryChainBuilder<TQuery, TQueryResponse> AddQueryHandler<TQueryHandler>(TQueryHandler handler)
//        where TQueryHandler : IQueryHandler<TQuery, TQueryResponse>
//    {
//        //if (!typeof(IQueryHandler).IsAssignableFrom(queryType))
//        //{
//        //    throw new ArgumentException("Type must implement IQuery", nameof(handler));
//        //}

//        chain.Add(typeof(TQueryHandler));
//        handlers.Add(handler);
//        return this;
//    }

//    public QueryChain<TQuery, TQueryResponse> Build()
//    {
//        return new QueryChain<TQuery, TQueryResponse>(handlers);
//    }
//}
