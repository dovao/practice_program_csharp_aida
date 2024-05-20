using System.Globalization;
using CoffeeMachineApp.core;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachineApp.Tests.core;

public abstract class NotifierTest
{
    private DrinkMakerDriver _drinkMakerDriver;
    private Notifier _notifier;

    [SetUp]
    public void SetUp()
    {
        _drinkMakerDriver = Substitute.For<DrinkMakerDriver>();
        _notifier = GetNotifier(_drinkMakerDriver);
    }

    [Test]
    public void Send_Select_Drink()
    {
        _notifier.NotifySelectDrink();

        CheckSelectDrinkMessage(_drinkMakerDriver);
    }

    [Test]
    public void Send_Missing_Price()
    {
        var missingMoney = 0.5m;
        
        _notifier.NotifyMissingPrice(missingMoney);
        
        
        CheckMissingMoneyMessage(_drinkMakerDriver, missingMoney);
    }

    protected abstract Notifier GetNotifier(DrinkMakerDriver drinkMakerDriver);
    protected abstract void CheckSelectDrinkMessage(DrinkMakerDriver drinkMakerDriver);
    protected abstract void CheckMissingMoneyMessage(DrinkMakerDriver drinkMakerDriver, decimal missingPriceAmount);

    protected CultureInfo GetCultureInfo(string name)
    {
        return new CultureInfo(name);
    }
}