using TelegramBot.Domain.Common.Entities;

namespace TelegramBot.Domain.Entities;

public class Message : Entity
{
    public string PhoneNumber { get; set; } = default!;

    public int Code { get; set; }
}