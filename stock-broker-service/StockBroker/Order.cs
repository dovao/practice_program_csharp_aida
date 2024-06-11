using System;

namespace StockBroker;

public class Order
{
    public Order(string tickerSymbol, int quantity, double price, TypeOrder type)
    {
        TickerSymbol = tickerSymbol;
        Quantity = quantity;
        Price = price;
        Type = type;
    }

    public TypeOrder Type { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string TickerSymbol { get; set; }

    protected bool Equals(Order other)
    {
        return Type == other.Type && Price.Equals(other.Price) && Quantity == other.Quantity && TickerSymbol == other.TickerSymbol;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Order)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Type, Price, Quantity, TickerSymbol);
    }

    public override string ToString()
    {
        return
            $"{nameof(Type)}: {Type}, {nameof(Price)}: {Price}, {nameof(Quantity)}: {Quantity}, {nameof(TickerSymbol)}: {TickerSymbol}";
    }
}