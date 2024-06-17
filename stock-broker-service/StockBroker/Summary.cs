using System.Collections.Generic;

namespace StockBroker;

public class Summary
{
    private Orders _buyOrders;
    private Orders _sellOrders;
    private Orders _ordersFailed;

    public Summary()
    {
        _buyOrders = new Orders();
        _sellOrders = new Orders();
        _ordersFailed = new Orders();
    }
    public double GetTotalBuy()
    {
        return _buyOrders.GetTotal();
    }

    public double GetTotalSell()
    {
        return _sellOrders.GetTotal();
    }

    public void AddOrder(Order order)
    {
        if (order.Type == TypeOrder.Buy)
        {
            _buyOrders.Add(order);
        }
        else
        {
            _sellOrders.Add(order);
        }
    }

    public void AddOrderFailed(Order order)
    {
        _ordersFailed.Add(order);
    }

    public override string ToString()
    {
        return $"{nameof(_buyOrders)}: {_buyOrders}, {nameof(_sellOrders)}: {_sellOrders}";
    }

    public List<Order> GetOrdersFailed()
    {
        return _ordersFailed.Get();
    }
}