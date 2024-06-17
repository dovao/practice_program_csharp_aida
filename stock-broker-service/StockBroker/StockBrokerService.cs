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
        var summary = new Summary();
        var messageComposer = new MessageComposer(_dateTimeProvider);

        if (!String.IsNullOrEmpty(orderSequence))
        {
           summary = GetSummaryFromOrdersSequence(orderSequence);
        }

        _output.Send(messageComposer.ComposeMessage(summary));
    }

    private Summary GetSummaryFromOrdersSequence(string orderSequence)
    {
        var summary = new Summary();
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
                summary.AddOrderFailed(order);
            }
        }

        return summary;
    }
}