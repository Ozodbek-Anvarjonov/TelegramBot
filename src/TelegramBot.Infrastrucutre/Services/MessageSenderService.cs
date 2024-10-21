using Microsoft.Extensions.Options;
using Telegram.Bot;
using TelegramBot.Application.Services;
using TelegramBot.Domain.Entities;
using TelegramBot.Infrastrucutre.Common.Settings;

namespace TelegramBot.Infrastrucutre.Services;

public class MessageSenderService(IOptions<BotSettings> options,
        IMessageService messageService,
        ITelegramBotClient client) : IMessageSenderService
{

    public async ValueTask<string> SendAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        var message = await messageService.CreateAsync(phoneNumber, cancellationToken) ??
            throw new ArgumentNullException();

        var text = await RenderingMessage(message);

        await client.SendTextMessageAsync(options.Value.ChatId, text);

        return text;
    }


    private ValueTask<string> RenderingMessage(Message message)
    {
        return new("PhoneNumber:" + message.PhoneNumber + " , Code:" + message.Code);
    }
}