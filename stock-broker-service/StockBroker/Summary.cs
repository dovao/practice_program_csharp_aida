using System.Collections.Generic;
using System.Linq;

namespace StockBroker;

public class Summary
{
    private List<Order> _orders = new List<Order>();

    public double GetTotalBuy()
    {
        var totalBuy = _orders.Where(o => o.Type == TypeOrder.Buy).Sum(o => o.Price * o.Quantity);
        return totalBuy;
    }

    public double GetTotalShell()
    {
        var totalBuy = _orders.Where(o => o.Type == TypeOrder.Shell).Sum(o => o.Price * o.Quantity);
        return totalBuy;
    }

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    public override string ToString()
    {
        return $"{nameof(_orders)}: {_orders}";
    }
}