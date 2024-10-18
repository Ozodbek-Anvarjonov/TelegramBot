using Microsoft.Extensions.Options;
using Telegram.Bot;
using TelegramBot.Application.Services;
using TelegramBot.Domain.Entities;
using TelegramBot.Infrastrucutre.Common.Settings;

namespace TelegramBot.Infrastrucutre.Services;

public class MessageSenderService : IMessageSenderService
{
    public readonly TelegramBotClient Client;
    public readonly BotSettings Options;
    public readonly IMessageService MessageService;

    public MessageSenderService(ICodeGeneratorService codeGeneratorService,
        IOptions<BotSettings> options,
        IMessageService messageService)
    {
        Client = new TelegramBotClient(options.Value.Token);
        Options = options.Value;
        MessageService = messageService;
    }

    public async ValueTask<string> SendAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        var message = await MessageService.CreateAsync(phoneNumber, cancellationToken) ??
            throw new ArgumentNullException();

        var text = await RenderingMessage(message);

        await Client.SendTextMessageAsync(Options.ChatId, text);

        return text;
    }


    private ValueTask<string> RenderingMessage(Message message)
    {
        return new("PhoneNumber:" + message.PhoneNumber + " , Code:" + message.Code);
    }
}