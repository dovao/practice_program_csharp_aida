using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using System.Diagnostics;

namespace StockBroker.Tests
{
    public class StockBrokerServiceTest
    {
        private DateTimeProvider _dateTimeProvider;
        private Output _output;
        private BrockerOnlineService _brockerOnlineService;
        private StockBrokerService _stockBrokerService;

        [SetUp]
        public void SetUp()
        {
            _dateTimeProvider = Substitute.For<DateTimeProvider>();
            _output = Substitute.For<Output>();
            _brockerOnlineService = Substitute.For<BrockerOnlineService>();
            _stockBrokerService = new StockBrokerService(_dateTimeProvider, _output, _brockerOnlineService);
        }

        [Test]
        public void empty_order_should_show_output_with_zero_summary_and_not_call_to_brocker_service()
        {
            _dateTimeProvider.Get().Returns(DateTime.Parse("15/08/2019 14:45:30"));

            _stockBrokerService.PlaceOrders("");

            _brockerOnlineService.Received(0).SendOrder(Arg.Any<Order>());
            _output.Received(1).Send("8/15/2019 2:45 PM Buy: \u20ac 0.00, Sell: \u20ac 0.00");
        }

        [Test]
        public void single_order_buy_should_show_output_with_summary_and_call_to_brocker_service()
        {
            _dateTimeProvider.Get().Returns(DateTime.Parse("25/07/2008 15:45:40"));

            _stockBrokerService.PlaceOrders("GOOG 300 829.08 B");

            _brockerOnlineService.Received(1).SendOrder(new("GOOG", 300, 829.08, TypeOrder.Buy));
            _output.Received(1).Send("7/25/2008 3:45 PM Buy: \u20ac 248724.00, Sell: \u20ac 0.00");
        }

        [Test]
        public void single_order_shell_should_show_output_with_summary_and_call_to_brocker_service()
        {
            _dateTimeProvider.Get().Returns(DateTime.Parse("25/07/2008 15:45:40"));

            _stockBrokerService.PlaceOrders("GOOG 300 829.08 S");

            _brockerOnlineService.Received(1).SendOrder(new("GOOG", 300, 829.08, TypeOrder.Shell));
            _output.Received(1).Send("7/25/2008 3:45 PM Buy: \u20ac 0.00, Sell: \u20ac 248724.00");
        }

        [Test]
        public void many_orders_should_show_output_with_summary_and_call_to_brocker_service()
        {
            _dateTimeProvider.Get().Returns(DateTime.Parse("15/06/2009 02:45:40"));

            _stockBrokerService.PlaceOrders("ZNGA 1300 2.78 B,AAPL 50 139.78 B,FB 320 137.17 S");

            _brockerOnlineService.Received(1).SendOrder(new("ZNGA", 1300, 2.78, TypeOrder.Buy));
            _brockerOnlineService.Received(1).SendOrder(new("AAPL", 50, 139.78, TypeOrder.Buy));
            _brockerOnlineService.Received(1).SendOrder(new("FB", 320, 137.17, TypeOrder.Shell));
            _output.Received(1).Send("6/15/2009 2:45 AM Buy: \u20ac 10603.00, Sell: \u20ac 43894.40");
        }
    }
}