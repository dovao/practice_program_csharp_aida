using System.Diagnostics;
using System.Globalization;
using CoffeeMachineApp.core;

namespace CoffeeMachineApp.infrastructure;

public class UkMessageComposer : core.MessageComposer
{
    public Message ComposeMissingMoneyMessage(decimal missingMoney)
    {
        var cultureInfo = new CultureInfo("en-EN");
        var result = missingMoney.ToString(cultureInfo);
        return Message.Create($"You are missing {result}");
    }

    public Message ComposeSelectDrinkMessage()
    {
        const string message = "Please, select a drink!";
        return Message.Create(message);
    }
}