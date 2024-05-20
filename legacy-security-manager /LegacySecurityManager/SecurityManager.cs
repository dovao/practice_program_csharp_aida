using System;

namespace LegacySecurityManager;

public class SecurityManager
{
    public static void CreateUser()
    {
        Console.WriteLine("Enter a username");
        var username = Console.ReadLine();
        Console.WriteLine("Enter your full name");
        var fullName = Console.ReadLine();
        Console.WriteLine("Enter your password");
        var password = Console.ReadLine();
        Console.WriteLine("Re-enter your password");
        var confirmPassword = Console.ReadLine();

        if (password != confirmPassword)
        {
            Console.WriteLine("The passwords don't match");
            return;
        }

        if (password.Length < 8)
        {
            Console.WriteLine("Password must be at least 8 characters in length");
            return;
        }

        // Encrypt the password (just reverse it, should be secure)
        char[] array = password.ToCharArray();
        Array.Reverse(array);

        Console.WriteLine("Saving Details for User ({0}, {1}, {2})\n", username, fullName, new string(array));
    }
}