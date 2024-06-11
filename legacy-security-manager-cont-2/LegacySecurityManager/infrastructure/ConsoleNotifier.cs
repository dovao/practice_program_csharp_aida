using System;

namespace LegacySecurityManager.infrastructure;

public class ConsoleNotifier : Notifier
{
    public void Notify(string message)
    {
        Console.WriteLine(message);
    }
}