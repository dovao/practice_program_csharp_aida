using CoffeeMachineApp.core;
using CoffeeMachineApp.infrastructure;
using NSubstitute;
using NUnit.Framework;
using static CoffeeMachineApp.Tests.helpers.OrderBuilder;

namespace CoffeeMachineApp.Tests.infrastructure;

public class DrinkMakerDriver800Test
{
    private DrinkMaker _drinkMaker;
    private DrinkMakerDriver800 _drinkMakerDriver800;

    [SetUp]
    public void SetUp()
    {
        _drinkMaker = Substitute.For<DrinkMaker>();
        _drinkMakerDriver800 = new DrinkMakerDriver800(_drinkMaker);
    }

    [Test]
    public void Serves_Chocolate()
    {
        _drinkMakerDriver800.Send(Chocolate().Build());

        _drinkMaker.Received().Execute("H::");
    }

    [Test]
    public void Serves_Tea()
    {
        _drinkMakerDriver800.Send(Tea().Build());

        _drinkMaker.Received().Execute("T::");
    }

    [Test]
    public void Serves_Coffee()
    {
        _drinkMakerDriver800.Send(Coffee().Build());

        _drinkMaker.Received().Execute("C::");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void Serves_Any_Drink_With_Sugar(int spoonsOfSugar)
    {
        _drinkMakerDriver800.Send(Chocolate().WithSpoonsOfSugar(spoonsOfSugar).Build());

        _drinkMaker.Received().Execute($"H:{spoonsOfSugar}:0");
    }

    [Test]
    public void Notifies_The_User()
    {
        var anyText = "any message";
        _drinkMakerDriver800.Notify(Message.Create(anyText));

        _drinkMaker.Received().Execute($"M:{anyText}");
    }
}