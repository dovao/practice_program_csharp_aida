using CoffeeMachineApp.core;
using CoffeeMachineApp.infrastructure.notifiers;
using CoffeeMachineApp.Tests.core;
using NSubstitute;

namespace CoffeeMachineApp.Tests.infrastructure.notifiers;

public class CurrentCultureWithDecimalCommaSeparatorNotifierTest : NotifierTest
{
    private const string CultureInfoName = "es-Es";

    protected override Notifier GetNotifier(DrinkMakerDriver drinkMakerDriver)
    {
        return new CurrentCultureWithDecimalCommaSeparatorNotifier(
            GetCultureInfo(CultureInfoName),
            drinkMakerDriver
        );
    }

    protected override void CheckMissingMoneyMessage(DrinkMakerDriver drinkMakerDriver, decimal missingPriceAmount)
    {
        drinkMakerDriver.Received(1).Notify(
            Message.Create($"You're missing {missingPriceAmount.ToString(GetCultureInfo(CultureInfoName))}")
        );
    }

    protected override void CheckSelectDrinkMessage(DrinkMakerDriver drinkMakerDriver)
    {
        drinkMakerDriver.Received(1).Notify(Message.Create("Please, select a drink!"));
    }
}