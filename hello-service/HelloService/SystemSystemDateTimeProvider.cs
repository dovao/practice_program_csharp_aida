using System;

namespace Hello;

public class SystemSystemDateTimeProvider : ISystemDateTimeProvider
{
    public DateTime GetDateTime()
    {
        return DateTime.Now;
    }
}