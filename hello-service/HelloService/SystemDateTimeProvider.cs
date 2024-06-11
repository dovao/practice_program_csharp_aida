using System;

namespace Hello;

public class SystemDateTimeProvider : DateTimeProvider
{
    public DateTime GetDateTime()
    {
        return DateTime.Now;
    }
}