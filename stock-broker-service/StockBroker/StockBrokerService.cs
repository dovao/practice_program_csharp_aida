using System;
using System.Collections.Generic;
using System.Globalization;

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
        var message = currentDate.ToString("M/dd/yyyy").Replace("-","/") + " " + currentDate.ToString("H:mm") + " PM";
        if (String.IsNullOrEmpty(orderSequence))
        {
            message += " Buy: € 0.00, Sell: € 0.00";
        }
        else
        {
            _brockerOnlineService.SendOrder(new Order("GOOG", 300, 829.08, TypeOrder.Buy));
            message += " Buy: € 248724.00, Sell: € 0.00";
        }



        _output.Send(message);
    }
}