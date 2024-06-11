using System;

namespace LegacySecurityManager.infrastructure;

public class ConsoleInput : Input {
    public string Request(string requestMessage)
    {
        Console.WriteLine(requestMessage);
        return Console.ReadLine();
    }
}