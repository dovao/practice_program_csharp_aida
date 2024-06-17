using System;
using System.Collections.Generic;

namespace StockBroker;

public class MessageComposer
{
    private readonly DateTimeProvider _dateTimeProvider;

    public MessageComposer(DateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string ComposeMessage(Summary summary)
    {
        return $"{FormatCurrentDate()}{GetSummaryFormat(summary)}{GetFailOrderFormat(summary.GetOrdersFailed())}";
    }

    private string GetFailOrderFormat(List<Order> ordersFailed)
    {
        var message = "";
        if (ordersFailed.Count > 0)
        {
            message += $", Failed:";

            foreach (var order in ordersFailed)
            {
                message += " " + order.TickerSymbol + ",";
            }

            message = message.Substring(0, message.Length - 1);
        }

        return message;
    }

    private string GetSummaryFormat(Summary summary)
    {
        return $" Buy: € {summary.GetTotalBuy().ToString("F")}, Sell: € {summary.GetTotalSell().ToString("F")}";
    }

    private string FormatCurrentDate()
    {
        var currentDate = _dateTimeProvider.Get();
        return currentDate.ToString("M/dd/yyyy").Replace("-", "/") + " " + currentDate.ToString("h:mm tt");
    }
}