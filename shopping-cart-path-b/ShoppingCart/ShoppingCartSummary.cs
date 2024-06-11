using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart;

public class ShoppingCartSummary
{
    private readonly List<Product> _products;
    public decimal TotalPrice { get; }
    public IEnumerable<ShoppingCartSummaryItem> Items { get; }

    public ShoppingCartSummary(List<Product> products, decimal totalPrice)
    {
        _products = products;
        TotalPrice = totalPrice;
        Items = CreateItems(products);
    }
    
    public int TotalProducts()
    {
        return _products.Count;
    }

    private IEnumerable<ShoppingCartSummaryItem> CreateItems(List<Product> products)
    {
        return products
            .GroupBy(p => p.ProductName)
            .Select(CreateItem);
    }

    private ShoppingCartSummaryItem CreateItem(IGrouping<string, Product> productGrouping)
    {
        var name = productGrouping.Key;
        var quantity = productGrouping.Count();
        var totalCost = productGrouping.First().ComputeCost() * quantity;
        return new ShoppingCartSummaryItem(name, quantity, totalCost);
    }

}