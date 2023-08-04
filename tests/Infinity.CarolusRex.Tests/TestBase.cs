using Microsoft.Extensions.DependencyInjection;

namespace Infinity.CarolusRex.Tests;

public class TestBase
{
    public static ServiceProvider ConfigureServiceProvider(Action<IServiceCollection> configure)
    {
        var services = new ServiceCollection();
        services.AddLogging();

        configure(services);
        return services.BuildServiceProvider();
    }

    public static IConfiguration CreateConfiguration(Dictionary<string, string?> configurationValues) => new ConfigurationBuilder()
            .AddInMemoryCollection(configurationValues)
            .Build();
}
