namespace Hello;

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
        _output.Send("Buenos d�as!");
    }
}