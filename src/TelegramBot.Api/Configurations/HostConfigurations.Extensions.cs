using TelegramBot.Application.Services;
using TelegramBot.Infrastrucutre.Common.Settings;
using TelegramBot.Infrastrucutre.Services;

namespace TelegramBot.Api.Configurations;

public static partial class HostConfigurations
{
    private static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<BotSettings>(builder.Configuration.GetSection(nameof(BotSettings)));

        builder.Services
            .AddScoped<IMessageService, MessageService>()
            .AddScoped<IMessageSenderService, MessageSenderService>()
            .AddScoped<IVerifyNumberService, VerifyNumberService>()
            .AddScoped<ICodeGeneratorService, CodeGeneratorService>();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllers();

        return builder;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI();

        return app;
    }
}