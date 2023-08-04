namespace Infinity.CarolusRex.Queries;

public interface IQueryHandler
{
}

public interface IQueryHandler<in TQuery> : IQueryHandler
{
    ValueTask Handle(TQuery query, IQueryContext context, CancellationToken ct);
}

/// <summary>
/// Defines a handler for a query.
/// </summary>
/// <typeparam name="TQuery">The type of query.</typeparam>
/// <typeparam name="TQueryResult">The of response.</typeparam>
public interface IQueryHandler<in TQuery, TQueryResult>
    where TQuery : IQuery<TQueryResult>
{
    /// <summary>
    /// Handles a query.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="ct">CancellationToken.</param>
    /// <returns>Response from the query.</returns>
    ValueTask<TQueryResult> Handle(TQuery query, CancellationToken ct);
}

/// <summary>
/// Marker interface to represent a query and it's response.
/// </summary>
public interface IQuery<TQueryResult>
{
}

public interface IQueryContext
{
}
