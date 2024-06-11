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
        _output.Send("8/15/2019 2:45 PM Buy: € 0.00, Sell: € 0.00");
    }
}