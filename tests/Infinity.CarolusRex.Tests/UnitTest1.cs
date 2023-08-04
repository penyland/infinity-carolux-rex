using Infinity.CarolusRex.Queries;

namespace Infinity.CarolusRex.Tests;

public class UnitTest1 : TestBase
{
    [Fact]
    public async Task Test1()
    {
        var services = ConfigureServiceProvider(services =>
        {
            services
                .AddCompositeQuery<Query1, Query1Context>()
                    .AddQueryHandler<QueryHandler1>()
                    .AddQueryHandler<QueryHandler2>();
        });

        var composite = services.GetRequiredService<CompositeQuery<Query1, Query1Context>>();

        await composite.RunAsync(new Query1("1"), CancellationToken.None);
    }
}
