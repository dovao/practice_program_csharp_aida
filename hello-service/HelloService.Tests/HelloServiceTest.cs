using NSubstitute;
using NUnit.Framework;

namespace Hello.Tests
{
    public class HelloServiceTest
    {
        [Test]
        public void say_good_morning_at_six_o_clock()
        {
            var dateTimeProvider = Substitute.For<DateTimeProvider>();
            var output = Substitute.For<Output>();
            dateTimeProvider.GetDateTime().Returns(DateTime.Parse("01/02/2024 06:00:00"));
            var helloService = new HelloService(dateTimeProvider, output);

            helloService.Hello();

            output.Received(1).Send("Buenos días!");
        }

        [Test]
        public void say_good_afternoon_at_twelve_o_clock()
        {
            var dateTimeProvider = Substitute.For<DateTimeProvider>();
            var output = Substitute.For<Output>();
            dateTimeProvider.GetDateTime().Returns(DateTime.Parse("01/02/2024 12:00:00"));
            var helloService = new HelloService(dateTimeProvider, output);

            helloService.Hello();

            output.Received(1).Send("Buenos tardes!");
        }
    }
}