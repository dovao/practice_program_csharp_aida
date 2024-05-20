using System;

namespace CoffeeMachineApp.core;

public class Order
{
    private DrinkType _drinkType;
    private int _spoonOfSugar;

    public Order(DrinkType drinkType, int spoonsOfSugar)
    {
        _drinkType = drinkType;
        _spoonOfSugar = spoonsOfSugar;
    }

    public Order() : this(DrinkType.None, 0)
    {
    }

    public DrinkType GetDrinkType()
    {
        return _drinkType;
    }

    public void AddSpoonOfSugar()
    {
        if (_spoonOfSugar < 2) _spoonOfSugar += 1;
    }

    public int GetSpoonsOfSugar()
    {
        return _spoonOfSugar;
    }

    public void SelectDrink(DrinkType drinkType)
    {
        _drinkType = drinkType;
    }

    protected bool Equals(Order other)
    {
        return _drinkType == other._drinkType && _spoonOfSugar == other._spoonOfSugar;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Order)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)_drinkType, _spoonOfSugar);
    }

    public override string ToString()
    {
        return $"{nameof(_drinkType)}: {_drinkType}, {nameof(_spoonOfSugar)}: {_spoonOfSugar}";
    }
}