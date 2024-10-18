using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.Services;

namespace TelegramBot.Infrastrucutre.Services;

public class CodeGeneratorService : ICodeGeneratorService
{
    public ValueTask<int> GenerateCode()
    {
        var random = new Random();

        return new(random.Next(100000, 999999));
    }
}
