using System;
using System.Collections.Generic;

namespace StockBroker;

public class MessageComposer
{
    private readonly DateTimeProvider _dateTimeProvider;
    private Summary _summary;
    private List<Order> _ordersFailed;

    public MessageComposer(DateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public void AddOrdersFailed(List<Order> ordersFailed)
    {
        _ordersFailed = ordersFailed;
    }

    public void AddSummary(Summary summary)
    {
        _summary = summary;
    }

    public string ComposeMessage()
    {
        return $"{FormatCurrentDate()}{GetSummaryFormat()}{GetFailOrderFormat()}";
    }

    private string GetFailOrderFormat()
    {
        var message = "";
        if (_ordersFailed.Count > 0)
        {
            message += $", Failed:";

            foreach (var order in _ordersFailed)
            {
                message += " " + order.TickerSymbol + ",";
            }

            message = message.Substring(0, message.Length - 1);
        }

        return message;
    }

    private string GetSummaryFormat()
    {
        return $" Buy: € {_summary.GetTotalBuy().ToString("F")}, Sell: € {_summary.GetTotalShell().ToString("F")}";
    }

    private string FormatCurrentDate()
    {
        var currentDate = _dateTimeProvider.Get();
        return currentDate.ToString("M/dd/yyyy").Replace("-", "/") + " " + currentDate.ToString("h:mm tt");
    }
}