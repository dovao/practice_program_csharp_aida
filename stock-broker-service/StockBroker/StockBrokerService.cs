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
        var ordersFailed = new List<Order>();
        var message = currentDate.ToString("M/dd/yyyy").Replace("-","/") + " " + currentDate.ToString("h:mm tt");
        if (String.IsNullOrEmpty(orderSequence))
        {
            message += $" Buy: € {summary.GetTotalBuy().ToString("F")}, Sell: € {summary.GetTotalShell().ToString("F")}";
        }
        else
        {
            var orders = OrderExtractor.ExtractOrders(orderSequence);

            foreach (var order in orders)
            {
                try
                {
                    _brockerOnlineService.SendOrder(order);
                    summary.AddOrder(order);
                }
                catch (Exception e)
                {
                    ordersFailed.Add(order);
                }
            }

            message += $" Buy: € {summary.GetTotalBuy().ToString("F")}, Sell: € {summary.GetTotalShell().ToString("F")}";

            if (ordersFailed.Count > 0)
            {
                message += $", Failed:";

                foreach (var order in ordersFailed)
                {
                    message += " " + order.TickerSymbol + ",";
                }

                message = message.Substring(0, message.Length - 1);
            }
        }

        _output.Send(message);
    }
}