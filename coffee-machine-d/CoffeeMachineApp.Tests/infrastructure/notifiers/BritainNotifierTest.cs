using CoffeeMachineApp.core;
using CoffeeMachineApp.infrastructure.notifiers;
using CoffeeMachineApp.Tests.core;
using NSubstitute;

namespace CoffeeMachineApp.Tests.infrastructure.notifiers;

public class BritainNotifierTest : NotifierTest
{
    private const string CultureInfoName = "en-GB";

    protected override Notifier GetNotifier(DrinkMakerDriver drinkMakerDriver)
    {
        return new CultureBasedNotifier(GetCultureInfo(CultureInfoName), drinkMakerDriver);
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