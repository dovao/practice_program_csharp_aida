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
    }

    public interface Output
    {
        void Send(string message);
    }

    public interface DateTimeProvider
    {
        DateTime GetDateTime();
    }

    public class HelloService
    {
        private readonly DateTimeProvider _dateTimeProvider;
        private readonly Output _output;

        public HelloService(DateTimeProvider dateTimeProvider, Output output)
        {
            _dateTimeProvider = dateTimeProvider;
            _output = output;
        }

        public void Hello()
        {
            _output.Send("Buenos días!");
        }
    }
}