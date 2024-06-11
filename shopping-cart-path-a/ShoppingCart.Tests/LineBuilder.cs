namespace ShoppingCart.Tests;

public class LineBuilder
{
    private decimal _priceWithVat;
    private string _productName;

    public LineBuilder(string productName, decimal priceWithVat)
    {
        _priceWithVat = priceWithVat;
        _productName = productName;
    }

    public LineBuilder Named(string productName)
    {
        _productName = productName;
        return this;
    }

    public LineBuilder Costing(decimal priceWithVat)
    {
        _priceWithVat = priceWithVat;
        return this;
    }

    public Line Build()
    {
        return new Line(_productName, _priceWithVat);
    }

    public static LineBuilder LineForProduct()
    {
        return new LineBuilder("Pepe", 1);
    }
}