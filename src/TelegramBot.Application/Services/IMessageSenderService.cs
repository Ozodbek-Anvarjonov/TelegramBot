namespace TelegramBot.Application.Services;

public interface IMessageSenderService
{
    ValueTask<string> SendAsync(string phoneNumber, CancellationToken cancellationToken = default);
}