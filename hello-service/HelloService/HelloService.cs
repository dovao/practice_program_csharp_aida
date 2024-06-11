using System;

namespace Hello;

public class HelloService
{
    private readonly DateTimeProvider _dateTimeProvider;
    private readonly Output _output;
    private const string GOOD_MORNING_MESSAGE = "Buenos días!";
    private const string GOOD_AFTERNOON_MESSAGE = "Buenas tardes!";
    private const string GOOD_NIGHT_MESSAGE = "Buenas noches!";

    public HelloService(DateTimeProvider dateTimeProvider, Output output)
    {
        _dateTimeProvider = dateTimeProvider;
        _output = output;
    }

    public void Hello()
    {
        var currentHour = _dateTimeProvider.GetDateTime().Hour;
        var message = GOOD_NIGHT_MESSAGE;

        if (IsMorning(currentHour))
        {
            message = GOOD_MORNING_MESSAGE;
        }
        else if(IsAfternoon(currentHour))
        {
            message = GOOD_AFTERNOON_MESSAGE;
        }

        _output.Send(message);
    }

    private bool IsMorning(int hour)
    {
        return hour >= 6 && hour < 12;
    }

    private bool IsAfternoon(int hour)
    {
        return hour >= 12 && hour < 21;
    }
}