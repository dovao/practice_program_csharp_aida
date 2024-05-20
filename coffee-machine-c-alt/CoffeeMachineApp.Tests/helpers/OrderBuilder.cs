using CoffeeMachineApp.core;

namespace CoffeeMachineApp.Tests.helpers;

public class OrderBuilder
{
    private DrinkType _drink;
    private int _spoonsOfSugar;

    private OrderBuilder()
    {
        _spoonsOfSugar = 0;
        _drink = DrinkType.None;
    }

    public static OrderBuilder Chocolate()
    {
        var builder = new OrderBuilder();
        builder._drink = DrinkType.Chocolate;
        return builder;
    }

    public static OrderBuilder Tea()
    {
        var builder = new OrderBuilder();
        builder._drink = DrinkType.Tea;
        return builder;
    }

    public static OrderBuilder Coffee()
    {
        var builder = new OrderBuilder();
        builder._drink = DrinkType.Coffee;
        return builder;
    }

    public OrderBuilder WithSpoonsOfSugar(int spoonsOfSugar)
    {
        _spoonsOfSugar = spoonsOfSugar;
        return this;
    }

    public Order Build()
    {
        return new Order(_drink, _spoonsOfSugar);
    }
}