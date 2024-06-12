using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;

namespace StockBroker;

public class StockBrokerService
{
    private readonly DateTimeProvider _dateTimeProvider;
    private readonly Output _output;
    private readonly BrockerOnlineService _brockerOnlineService;

    public StockBrokerService(DateTimeProvider dateTimeProvider, Output output, BrockerOnlineService brockerOnlineService)
    {
        _dateTimeProvider = dateTimeProvider;
        _output = output;
        _brockerOnlineService = brockerOnlineService;
    }

    public void PlaceOrders(string orderSequence)
    {
        var currentDate = _dateTimeProvider.Get();
        var summary = new Summary();
        var message = currentDate.ToString("M/dd/yyyy").Replace("-","/") + " " + currentDate.ToString("h:mm tt");
        if (String.IsNullOrEmpty(orderSequence))
        {
            message += $" Buy: € {summary.GetTotalBuy().ToString("F")}, Sell: € {summary.GetTotalShell().ToString("F")}";
        }
        else
        {
            var orders = ExtractOrders(orderSequence);

            summary.AddOrders(orders);
            orders.ForEach(o => _brockerOnlineService.SendOrder(o));
            
            message += $" Buy: € {summary.GetTotalBuy().ToString("F")}, Sell: € {summary.GetTotalShell().ToString("F")}";
        }

        _output.Send(message);
    }

    private static List<Order> ExtractOrders(string orderSequence)
    {
        var ordersBySequence = orderSequence.Split(',').ToList();
        var order = ordersBySequence.Select(s => ExtractOrder(s)).ToList();
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