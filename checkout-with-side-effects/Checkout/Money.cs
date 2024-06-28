namespace Checkout;

public record Money
{
    private readonly decimal _value;

    public Money(int value)
    {
        _value = value;
    }

    public Money(decimal value)
    {
        _value = value;
    }

    public Money Add(Money other)
    {
        return new Money(_value + other._value);
    }

    public Money Percentage(int p)
    {
        return new Money(_value * p / 100);
    }

    public string Format()
    {
        return $"{_value:0.00}";
    }

    internal decimal AsDecimal()
    {
        return _value;
    }

    public override string ToString()
    {
        return "Money { " + _value + " }";
    }
}