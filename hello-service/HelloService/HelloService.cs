using System;

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
        var currentDate = _dateTimeProvider.GetDateTime();

        if (IsMorning(currentDate))
        {
            _output.Send("Buenos días!");
        }
        else if(IsAfternoon(currentDate))
        {
            _output.Send("Buenas tardes!");
        }
        else
        {
            _output.Send("Buenas noches!");
        }
    }

    private static bool IsAfternoon(DateTime currentDate)
    {
        return currentDate.Hour >= 12 && currentDate.Hour < 21;
    }

    private static bool IsMorning(DateTime currentDate)
    {
        return currentDate.Hour >= 6 && currentDate.Hour < 12;
    }
}