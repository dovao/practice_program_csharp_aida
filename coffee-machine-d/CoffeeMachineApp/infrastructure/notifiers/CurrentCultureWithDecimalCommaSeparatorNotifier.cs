using System.Globalization;
using CoffeeMachineApp.core;
using static System.Globalization.CultureInfo;

namespace CoffeeMachineApp.infrastructure.notifiers;

public class CurrentCultureWithDecimalCommaSeparatorNotifier : Notifier
{
    private readonly CultureInfo _messageCulture;
    private readonly DrinkMakerDriver _drinkMakerDriver;
    
    public static Notifier Create(DrinkMakerDriver drinkMakerDriver)
    {
        return new CurrentCultureWithDecimalCommaSeparatorNotifier(
            CurrentCulture,
            drinkMakerDriver
        );
    }
    public CurrentCultureWithDecimalCommaSeparatorNotifier(CultureInfo messageCulture, DrinkMakerDriver drinkMakerDriver)
    {
        _messageCulture = messageCulture;
        _drinkMakerDriver = drinkMakerDriver;
    }

    public void NotifyMissingPrice(decimal missingPrice)
    {
        _drinkMakerDriver.Notify(Message.Create($"You're missing {missingPrice.ToString(_messageCulture)}"));
    }

    public void NotifySelectDrink()
    {
        _drinkMakerDriver.Notify(Message.Create("Please, select a drink!"));
    }
}