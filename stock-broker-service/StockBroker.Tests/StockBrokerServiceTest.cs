using NSubstitute;
using NUnit.Framework;

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
        public void place_empty_orders_sequence()
        {
            _dateTimeProvider.Get().Returns(GetDate("15/08/2019 14:45:30"));

            _stockBrokerService.PlaceOrders("");

            _brockerOnlineService.Received(0).SendOrder(Arg.Any<Order>());
            _output.Received(1).Send("8/15/2019 2:45 PM Buy: € 0.00, Sell: € 0.00");
        }

        [Test]
        public void place_one_buy_order_of_several_stocks()
        {
            _dateTimeProvider.Get().Returns(GetDate("25/07/2008 15:45:40"));

            _stockBrokerService.PlaceOrders("GOOG 300 829.08 B");

            _brockerOnlineService.Received(1).SendOrder(BuyOrder("GOOG", 300, 829.08));
            _output.Received(1).Send("7/25/2008 3:45 PM Buy: € 248724.00, Sell: € 0.00");
        }



        [Test]
        public void place_one_sell_order_of_several_stocks()
        {
            _dateTimeProvider.Get().Returns(GetDate("25/07/2008 15:45:40"));

            _stockBrokerService.PlaceOrders("GOOG 300 829.08 S");

            _brockerOnlineService.Received(1).SendOrder(SellOrder("GOOG", 300, 829.08));
            _output.Received(1).Send("7/25/2008 3:45 PM Buy: € 0.00, Sell: € 248724.00");
        }



        [Test]
        public void many_orders_should_show_output_with_summary_and_call_to_brocker_service()
        {
            _dateTimeProvider.Get().Returns(GetDate("15/06/2009 02:45:40"));

            _stockBrokerService.PlaceOrders("ZNGA 1300 2.78 B,AAPL 50 139.78 B,FB 320 137.17 S");

            _brockerOnlineService.Received(1).SendOrder(BuyOrder("ZNGA", 1300, 2.78));
            _brockerOnlineService.Received(1).SendOrder(BuyOrder("AAPL", 50, 139.78));
            _brockerOnlineService.Received(1).SendOrder(SellOrder("FB", 320, 137.17));
            _output.Received(1).Send("6/15/2009 2:45 AM Buy: € 10603.00, Sell: € 43894.40");
        }

        [Test]
        public void when_brocker_online_service_fail_not_sum_failed_orders_and_show_order_with_errors()
        {
            var orderFail1 = SellOrder("FB", 320, 137.17);
            var orderFail2 = SellOrder("ORCL", 1000, 42.69);
            _brockerOnlineService
                .When(x => x.SendOrder(orderFail1))
                .Do(x => { throw new Exception("Broker online service failed"); });

            _brockerOnlineService
                .When(x => x.SendOrder(orderFail2))
                .Do(x => { throw new Exception("Broker online service failed"); });
            _dateTimeProvider.Get().Returns(DateTime.Parse("15/06/2009 13:45:40"));

            _stockBrokerService.PlaceOrders("ZNGA 1300 2.78 B,AAPL 50 139.78 B,FB 320 137.17 S,ORCL 1000 42.69 S");

            _brockerOnlineService.Received(1).SendOrder(BuyOrder("ZNGA", 1300, 2.78));
            _brockerOnlineService.Received(1).SendOrder(BuyOrder("AAPL", 50, 139.78));
            _brockerOnlineService.Received(1).SendOrder(orderFail1);
            _brockerOnlineService.Received(1).SendOrder(orderFail2);
            _output.Received(1).Send("6/15/2009 1:45 PM Buy: € 10603.00, Sell: € 0.00, Failed: FB, ORCL");
        }

        [Test]
        public void when_call_several_to_place_orders_show_last()
        {
            _dateTimeProvider.Get().Returns(GetDate("25/07/2008 15:45:40"));
            _stockBrokerService.PlaceOrders("GOOG 400 829.08 S");

            _stockBrokerService.PlaceOrders("GOOG 300 829.08 S");

            _brockerOnlineService.Received(1).SendOrder(SellOrder("GOOG", 300, 829.08));
            _output.Received(1).Send("7/25/2008 3:45 PM Buy: € 0.00, Sell: € 248724.00");
        }

        private static Order BuyOrder(string tickerSymbol, int quantity, double price)
        {
            return new Order(tickerSymbol, quantity, price, TypeOrder.Buy);
        }

        private static Order SellOrder(string tickerSymbol, int quantity, double price)
        {
            return new(tickerSymbol, quantity, price, TypeOrder.Shell);
        }

        private static DateTime GetDate(string dateString)
        {
            return DateTime.Parse(dateString);
        }
    }
}