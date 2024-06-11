using System;

namespace Hello.Infrastructure;

public class ConsoleOutput : Output
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}