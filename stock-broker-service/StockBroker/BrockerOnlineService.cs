using System.Collections.Generic;

namespace StockBroker;

public interface BrockerOnlineService
{
    void SendOrder(Order order);
}