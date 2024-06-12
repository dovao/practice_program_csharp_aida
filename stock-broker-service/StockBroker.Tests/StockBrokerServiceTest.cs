using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using System.Diagnostics;

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

            brockerOnlineService.Received(0).SendOrder(Arg.Any<Order>());
            output.Received(1).Send("8/15/2019 2:45 PM Buy: \u20ac 0.00, Sell: \u20ac 0.00");
        }

        [Test]
        public void single_order_buy_should_show_output_with_summary_and_call_to_brocker_service()
        {
            var dateTimeProvider = Substitute.For<DateTimeProvider>();
            var output = Substitute.For<Output>();
            var brockerOnlineService = Substitute.For<BrockerOnlineService>();
            dateTimeProvider.Get().Returns(DateTime.Parse("25/07/2008 3:45:40"));
            var stockBrokerService = new StockBrokerService(dateTimeProvider, output, brockerOnlineService);

            stockBrokerService.PlaceOrders("GOOG 300 829.08 B");

            brockerOnlineService.Received(1).SendOrder(new("GOOG", 300, 829.08, TypeOrder.Buy));
            output.Received(1).Send("7/25/2008 3:45 PM Buy: \u20ac 248724.00, Sell: \u20ac 0.00");
        }

        [Test]
        public void single_order_shell_should_show_output_with_summary_and_call_to_brocker_service()
        {
            var dateTimeProvider = Substitute.For<DateTimeProvider>();
            var output = Substitute.For<Output>();
            var brockerOnlineService = Substitute.For<BrockerOnlineService>();
            dateTimeProvider.Get().Returns(DateTime.Parse("25/07/2008 3:45:40"));
            var stockBrokerService = new StockBrokerService(dateTimeProvider, output, brockerOnlineService);

            stockBrokerService.PlaceOrders("GOOG 300 829.08 S");

            brockerOnlineService.Received(1).SendOrder(new("GOOG", 300, 829.08, TypeOrder.Shell));
            output.Received(1).Send("7/25/2008 3:45 PM Buy: \u20ac 0.00, Sell: \u20ac 248724.00");
        }
    }
}