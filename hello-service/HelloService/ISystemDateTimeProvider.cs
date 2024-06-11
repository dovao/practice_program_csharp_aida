using System;

namespace Hello;

public interface ISystemDateTimeProvider
{
    DateTime GetDateTime();
}