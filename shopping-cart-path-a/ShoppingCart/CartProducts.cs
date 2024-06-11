using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart;

internal class CartProducts
{
    private List<Product> _products;

    public CartProducts()
    {
        _products = new List<Product>();
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public bool ThereAreNoProducts()
    {
        return !_products.Any();
    }

    public decimal ComputeAllProductsCost()
    {
        return _products.Sum(p => p.ComputeCost());
    }

    public ContentsSummary CreateContentsSummary()
    {
        var lines = _products.Select(p => new Line(p.Name, p.ComputeCost())).ToList();
        return new ContentsSummary(lines);
    }
}