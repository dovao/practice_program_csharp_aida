using System.Globalization;
using CoffeeMachineApp.core;

namespace CoffeeMachineApp.infrastructure.notifiers;

public class CultureBasedNotifier : Notifier
{
    private readonly CultureInfo _messageCulture;
    private readonly DrinkMakerDriver _drinkMakerDriver;

    public CultureBasedNotifier(CultureInfo messageCulture, DrinkMakerDriver drinkMakerDriver)
    {
        _messageCulture = messageCulture;
        _drinkMakerDriver = drinkMakerDriver;
    }

    public void NotifyMissingPrice(decimal missingPrice)
    {
        _drinkMakerDriver.Notify(CreateMissingPriceMessage(missingPrice));
    }

    public void NotifySelectDrink()
    {
        _drinkMakerDriver.Notify(CreateSelectDrinkMessage());
    }

    private Message CreateSelectDrinkMessage()
    {
        return GenerateMessage(GetSelectDrinkMessageContent());
    }

    private string GetSelectDrinkMessageContent()
    {
        return _messageCulture.Name switch
        {
            "en-GB" => "Please, select a drink!",
            "es-ES" => "Por favor, ¡selecciona una bebida!",
            "es-PR" => "Por favor, ¡selecciona una bebida!",
            _ => string.Empty
        };
    }

    private Message CreateMissingPriceMessage(decimal missingPrice)
    {
        var messageContent = string.Format(GetMissingPriceMessageContent(), GetMissingPriceFormatted(missingPrice));
        return GenerateMessage(messageContent);
    }

    private string GetMissingPriceMessageContent()
    {
        return _messageCulture.Name switch
        {
            "en-GB" => "You're missing {0}",
            "es-ES" => "Te faltan {0}",
            "es-PR" => "Te faltan {0}",
            _ => string.Empty
        };
    }

    private string GetMissingPriceFormatted(decimal missingPrice)
    {
        return missingPrice.ToString(_messageCulture);
    }

    private static Message GenerateMessage(string messageContent)
    {
        return Message.Create(messageContent);
    }
}