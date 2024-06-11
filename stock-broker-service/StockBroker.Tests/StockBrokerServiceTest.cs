using NSubstitute;
using NUnit.Framework;

namespace StockBroker.Tests
{
    public class StockBrokerServiceTest
    {
        [Test]
        public void empty_order_should_show_output_with_zero_summary_and_not_call_to_brocker_service()
        {
            var dateTimeProvider = Substitute.For<DateTimeProvider>();
            var output = Substitute.For<Output>();
            var brockerOnlineService = Substitute.For<BrockerOnlineService>();
            dateTimeProvider.Get().Returns(DateTime.Parse("15/08/2019 2:45:30"));
            var stockBrokerService = new StockBrokerService(dateTimeProvider, output, brockerOnlineService);

            stockBrokerService.PlaceOrders("");

            output.Received(1).Send("8/15/2019 2:45 PM Buy: \u20ac 0.00, Sell: \u20ac 0.00");
        }
    }
}