using System.Runtime.CompilerServices;

namespace TelegramBot.Api.Configurations;

public static partial class HostConfigurations
{
    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseDevTools();
        app.UseExposers();

        return new(app);
    }

    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddInfrastructure()
            .AddDevTools()
            .AddExposers();

        return new ValueTask<WebApplicationBuilder>(builder);
    }
}