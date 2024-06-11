using System;

namespace LegacySecurityManager;

public class ConsoleInputReader : InputReader
{
    public string Read()
    {
        return Console.ReadLine();
    }
}