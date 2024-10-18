namespace TelegramBot.Application.Services;

public interface ICodeGeneratorService
{
    public ValueTask<int> GenerateCode();
}