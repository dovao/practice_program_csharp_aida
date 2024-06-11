using Hello.Infrastructure;

namespace Hello
{
    public class Program
    {
        static void Main(string[] args)
        {
            var helloService = new HelloService(new SystemDateTimeProvider(), new ConsoleOutput());

            helloService.Hello();
        }
    }
}
