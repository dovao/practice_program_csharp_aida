using System.Runtime.InteropServices;

namespace ShoppingCart;

public class Product
{
    private readonly string _productName;

    private readonly decimal _revenue;
    private readonly decimal _tax;
    private readonly decimal _cost;


    public Product(string productName, decimal cost, decimal revenue, decimal tax)
    {
        _productName = productName;
        _cost = cost;
        _revenue = revenue;
        _tax = tax;
    }

    public string ProductName => _productName;

    public decimal ComputeCost()
    {
        var costPlusRevenue = ApplyRevenue();
        return ApplyTaxes(costPlusRevenue);
    }

    private decimal ApplyTaxes(decimal costPlusRevenue)
    {
        return costPlusRevenue * (1 + _tax);
    }

    private decimal ApplyRevenue()
    {
        return (_cost * (1 + _revenue));
    }
}