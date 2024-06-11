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
        if (_dateTimeProvider.GetDateTime().Hour >= 6 && _dateTimeProvider.GetDateTime().Hour < 12)
            _output.Send("Buenos días!");
        else if(_dateTimeProvider.GetDateTime().Hour >= 12 && _dateTimeProvider.GetDateTime().Hour < 21)
        {
            _output.Send("Buenas tardes!");
        }
        else
        {
            _output.Send("Buenas noches!");
        }
    }
}