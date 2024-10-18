using TelegramBot.Application.Services;
using TelegramBot.Domain.Entities;

namespace TelegramBot.Infrastrucutre.Services;

public class MessageService(IVerifyNumberService verifyNumberService
    , ICodeGeneratorService codeGeneratorService) : IMessageService
{
    public async ValueTask<Message?> CreateAsync(string phoneNumber, CancellationToken cancellationToken)
    {
        if (!await verifyNumberService.VerifyNumber(phoneNumber))
            return null;

        var message = new Message { Id = Guid.NewGuid(), PhoneNumber = phoneNumber, Code = await codeGeneratorService.GenerateCode() };

        return message;
    }
}