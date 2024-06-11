using System;

namespace Hello;

public class ConsoleOutput : Output
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}