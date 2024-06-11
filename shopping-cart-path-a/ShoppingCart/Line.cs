using System;

namespace ShoppingCart;

public class Line 
{
    private readonly string _productName;
    private readonly decimal _priceWithVat;

    public Line(string productName, decimal priceWithVat)
    {
        _productName = productName;
        _priceWithVat = priceWithVat;
    }

    protected bool Equals(Line other)
    {
        return _productName == other._productName && _priceWithVat.Equals(other._priceWithVat);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Line)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_productName, _priceWithVat);
    }

    public override string ToString()
    {
        return $"{nameof(_productName)}: {_productName}, {nameof(_priceWithVat)}: {_priceWithVat}";
    }
}