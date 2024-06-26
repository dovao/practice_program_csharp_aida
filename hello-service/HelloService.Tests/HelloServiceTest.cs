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

        [TestCase("06:00:00")]
        [TestCase("11:59:59")]
        [TestCase("10:34:52")]
        public void say_good_morning_in_morning(string time)
        {
            SetCurrentTime(time);

            _helloService.Hello();

            CheckOutputMessage("Buenos d�as!");
        }

        [TestCase("12:00:00")]
        [TestCase("19:59:59")]
        [TestCase("14:03:20")]
        public void say_good_afternoon_in_afternoon(string time)
        {
            SetCurrentTime(time);

            _helloService.Hello();

            CheckOutputMessage("Buenas tardes!");
        }


        [TestCase("21:00:00")]
        [TestCase("05:59:59")]
        [TestCase("00:02:57")]
        public void say_good_night_in_night(string time)
        {
            SetCurrentTime(time);

            _helloService.Hello();

            CheckOutputMessage("Buenas noches!");
        }

        private void SetCurrentTime(string time)
        {
           _dateTimeProvider.GetDateTime().Returns(DateTime.Parse("01/02/2024 " + time));
        }

        private void CheckOutputMessage(string message)
        {
            _output.Received(1).Send(message);
        }
    }
}