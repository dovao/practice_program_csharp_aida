using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ShoppingCartSummaryFormatter
    {
        private const string Header = "Product name, Price with VAT, Quantity\n";
        private readonly List<Product> _productList;
        private readonly decimal _computeTotalCost;

        public ShoppingCartSummaryFormatter(List<Product> productList, decimal computeTotalCost)
        {
            _productList = productList;
            _computeTotalCost = computeTotalCost;
        }

        public string Format()
        {
            var summary = new ShoppingCartSummary(_productList, _computeTotalCost);
            return $"{Header}" +
                   $"{CreateBody(summary)}" +
                   $"{CreateFooter(summary)}";
        }

        private string CreateFooter(ShoppingCartSummary summary)
        {
            return $"Total products: {summary.TotalProducts()}\nTotal price: {summary.TotalPrice}\u20ac";
        }

        private string CreateBody(ShoppingCartSummary summary)
        {
            if (summary.TotalProducts() == 0)
            {
                return "";
            }

            return summary.Items
                .Select(item => $"{item.Name}, {item.TotalCost}€, {item.Quantity}\n")
                .Aggregate("", (current, line) => current + line);
        }
    }
}