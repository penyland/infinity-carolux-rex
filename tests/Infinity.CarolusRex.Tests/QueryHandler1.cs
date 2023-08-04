using Infinity.CarolusRex.Queries;
using Xunit.Abstractions;

namespace Infinity.CarolusRex.Tests;

public record Query1(string Id);

public record Query1Context : IQueryContext;

internal class QueryHandler1 : IQueryHandler<Query1>
{
    private readonly ITestOutputHelper testOutputHelper;

    public QueryHandler1(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    public ValueTask Handle(Query1 query, IQueryContext context, CancellationToken ct)
    {
        testOutputHelper.WriteLine($"QueryHandler1: {query.Id}");

        return ValueTask.CompletedTask;
    }
}

internal class QueryHandler2 : IQueryHandler<Query1>
{
    private readonly ITestOutputHelper testOutputHelper;

    public QueryHandler2(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    public ValueTask Handle(Query1 query, IQueryContext context, CancellationToken ct)
    {
        testOutputHelper.WriteLine($"QueryHandler2: {query.Id}");

        return ValueTask.CompletedTask;
    }
}

internal class QueryHandler3 : IQueryHandler<Query1>
{
    public ValueTask Handle(Query1 query, IQueryContext context, CancellationToken ct)
    {
        Console.WriteLine($"QueryHandler3: {query.Id}");

        return ValueTask.CompletedTask;
    }
}
