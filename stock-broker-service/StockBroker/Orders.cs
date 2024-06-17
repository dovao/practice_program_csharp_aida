using System.Collections.Generic;
using System.Linq;

namespace StockBroker;

public class Orders
{
    private List<Order> _orders;

    public Orders()
    {
        _orders = new List<Order>();
    }

    public void Add(Order order)
    {
        _orders.Add(order);
    }

    public double GetTotal()
    {
        return _orders.Sum(o => o.Price * o.Quantity);
    }

    public List<Order> Get()
    {
        return _orders;
    }
}