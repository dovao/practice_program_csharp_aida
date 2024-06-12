using System;
using System.Data;
using System.Globalization;
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
        var message = currentDate.ToString("M/dd/yyyy").Replace("-","/") + " " + currentDate.ToString("H:mm") + " PM";
        if (String.IsNullOrEmpty(orderSequence))
        {
            message += $" Buy: € {summary.GetTotalBuy().ToString("F")}, Sell: € 0.00";
        }
        else
        {
            var order = new Order("GOOG", 300, 829.08, TypeOrder.Buy);
            summary.AddOrder(order);
            _brockerOnlineService.SendOrder(order);
            message += $" Buy: € {summary.GetTotalBuy().ToString("F")}, Sell: € 0.00";
        }

        _output.Send(message);
    }
}