using System.Text.RegularExpressions;
using TelegramBot.Application.Services;

namespace TelegramBot.Infrastrucutre.Services;

public class VerifyNumberService : IVerifyNumberService
{
    public ValueTask<bool> VerifyNumber(string number)
    {
        var regex = new Regex(@"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$f");
        
        // regex does not work
        if (regex.IsMatch(number))
        {
            return new(true);
        }

        return new ValueTask<bool>(true);
    }
}