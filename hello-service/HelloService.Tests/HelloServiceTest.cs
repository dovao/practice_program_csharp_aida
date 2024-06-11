using NSubstitute;
using NUnit.Framework;

namespace Hello.Tests
{
    public class HelloServiceTest
    {
        private DateTimeProvider _dateTimeProvider;
        private Output _output;
        private HelloService _helloService;

        [SetUp]
        public void SetUp()
        {
            _dateTimeProvider = Substitute.For<DateTimeProvider>();
            _output = Substitute.For<Output>();
            _helloService = new HelloService(_dateTimeProvider, _output);
        }

        [TestCase("01/02/2024 06:00:00")]
        [TestCase("01/02/2024 11:59:59")]
        [TestCase("01/02/2024 10:34:52")]
        public void say_good_morning_in_morning(string date)
        {
            _dateTimeProvider.GetDateTime().Returns(DateTime.Parse(date));

            _helloService.Hello();

            _output.Received(1).Send("Buenos d�as!");
        }

        [TestCase("01/02/2024 12:00:00")]
        public void say_good_afternoon_in_afternoon(string date)
        {
            _dateTimeProvider.GetDateTime().Returns(DateTime.Parse(date));

            _helloService.Hello();

            _output.Received(1).Send("Buenas tardes!");
        }

        [TestCase("01/02/2024 21:00:00")]
        public void say_good_night_in_night(string date)
        {
            _dateTimeProvider.GetDateTime().Returns(DateTime.Parse(date));

            _helloService.Hello();

            _output.Received(1).Send("Buenas noches!");
        }
    }
}