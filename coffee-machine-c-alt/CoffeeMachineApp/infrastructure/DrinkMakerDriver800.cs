using CoffeeMachineApp.core;

namespace CoffeeMachineApp.infrastructure;

public class DrinkMakerDriver800 : DrinkMakerDriver
{
    private readonly DrinkMaker _drinkMaker;

    public DrinkMakerDriver800(DrinkMaker drinkMaker)
    {
        _drinkMaker = drinkMaker;
    }

    public void Send(Order order)
    {
        _drinkMaker.Execute(ComposeCommand(order));
    }

    public void Notify(Message message)
    {
        _drinkMaker.Execute($"M:{message.GetText()}");
    }

    private string ComposeCommand(Order order)
    {
        return ComposeDrinkSection(order.GetDrinkType()) + ":" + ComposeSugarSection(order);
    }

    private static string ComposeDrinkSection(DrinkType drink)
    {
        return $"{GetDriverDrinkType(drink)}";
    }

    private static string GetDriverDrinkType(DrinkType drinkTypeEnum)
    {
        var drinkType = drinkTypeEnum switch
        {
            DrinkType.Chocolate => "H",
            DrinkType.Tea => "T",
            DrinkType.Coffee => "C",
            _ => "N"
        };

        return drinkType;
    }

    private string ComposeSugarSection(Order order)
    {
        var spoonsOfSugar = order.GetSpoonsOfSugar();
        var spoonOfSugarToString = spoonsOfSugar > 0 ? spoonsOfSugar.ToString() : string.Empty;
        var hasStickToString = spoonsOfSugar > 0 ? "0" : string.Empty;
        var sugarSection = $"{spoonOfSugarToString}:{hasStickToString}";
        return sugarSection;
    }
}