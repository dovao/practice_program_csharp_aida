using System.Collections.Generic;
using System.Linq;

namespace StockBroker;

public static class OrderExtractor
{
    public static List<Order> ExtractOrders(string orderSequence)
    {
        var ordersBySequence = orderSequence.Split(',').ToList();
        var order = ordersBySequence.Select<string, Order>(s => ExtractOrder(s)).ToList();
        return order;
    }

    private static Order ExtractOrder(string orderSequence)
    {
        var splitSequence = orderSequence.Split(' ');
        var tickerSymbol = splitSequence[0];
        var quantity = int.Parse(splitSequence[1]);
        var price = double.Parse(splitSequence[2]);
        var typeOrder = splitSequence[3] == "B" ? TypeOrder.Buy : TypeOrder.Shell;
        var order = new Order(tickerSymbol, quantity, price, typeOrder);
        return order;
    }
}