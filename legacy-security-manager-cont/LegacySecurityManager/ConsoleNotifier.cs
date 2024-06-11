using System;

namespace LegacySecurityManager;

public class ConsoleNotifier : Notifier
{
    public void Notify(string message)
    {
        Console.WriteLine(message);
    }
}