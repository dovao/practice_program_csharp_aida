using System;

namespace Hello.Infrastructure;

public class SystemDateTimeProvider : DateTimeProvider
{
    public DateTime GetDateTime()
    {
        return DateTime.Now;
    }
}