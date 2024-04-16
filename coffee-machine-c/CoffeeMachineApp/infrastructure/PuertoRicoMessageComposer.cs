using System.Globalization;
using CoffeeMachineApp.core;

namespace CoffeeMachineApp.infrastructure;

public class PuertoRicoMessageComposer : MessageComposer
{
    public Message ComposeMissingMoneyMessage(decimal missingMoney)
    {
        var cultureInfo = new CultureInfo("es-PR");
        var result = missingMoney.ToString(cultureInfo);
        return Message.Create($"Te falta {result}");
    }

    public Message ComposeSelectDrinkMessage()
    {
        return Message.Create("Por favor, seleccione una bebida.");
    }
}