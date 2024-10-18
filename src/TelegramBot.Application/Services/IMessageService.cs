using TelegramBot.Domain.Entities;

namespace TelegramBot.Application.Services;

public interface IMessageService
{
    ValueTask<Message?> CreateAsync(string phoneNumber, CancellationToken cancellationToken);
}