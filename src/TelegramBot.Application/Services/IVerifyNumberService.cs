namespace TelegramBot.Application.Services;

public interface IVerifyNumberService
{
    ValueTask<bool> VerifyNumber(string number);
}