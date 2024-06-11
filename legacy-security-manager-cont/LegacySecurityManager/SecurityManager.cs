using System;

namespace LegacySecurityManager;

public class SecurityManager
{
    private readonly InputReader _inputReader;
    private readonly Notifier _notifier;

    public SecurityManager(Notifier notifier, InputReader inputReader)
    {
        _notifier = notifier;
        _inputReader = inputReader;
    }

    public void CreateValidUser()
    {
        var username = RequestUserName();
        var fullName = RequestFullName();
        var password = RequestPassword();
        var confirmPassword = RequestPasswordConfirmation();

        if (PasswordsDoNotMatch(password, confirmPassword))
        {
            NotifyPasswordDoNotMatch();
            return;
        }

        if (IsPasswordToShort(password))
        {
            NotifyPasswordIsToShort();
            return;
        }

        var encryptedPassword = EncryptPassword(password);
        NotifyUserCreation(username, fullName, encryptedPassword);
    }

    private void NotifyPasswordIsToShort()
    {
        Print("Password must be at least 8 characters in length");
    }

    private void NotifyPasswordDoNotMatch()
    {
        Print("The passwords don't match");
    }

    private void NotifyUserCreation(string username, string fullName, string encryptedPassword)
    {
        Print($"Saving Details for User ({username}, {fullName}, {encryptedPassword})\n");
    }

    private static string EncryptPassword(string password)
    {
        var array = password.ToCharArray();
        Array.Reverse(array);
        var encryptedPassword = new string(array);
        return encryptedPassword;
    }

    private static bool IsPasswordToShort(string password)
    {
        return password.Length < 8;
    }

    private static bool PasswordsDoNotMatch(string password, string confirmPassword)
    {
        return password != confirmPassword;
    }

    private string RequestPasswordConfirmation()
    {
        return RequestUserInput("Re-enter your password");
    }

    private string RequestPassword()
    {
        return RequestUserInput("Enter your password");
    }

    private string RequestFullName()
    {
        return RequestUserInput("Enter your full name");
    }

    private string RequestUserName()
    {
        return RequestUserInput("Enter a username");
    }

    private string RequestUserInput(string requestMessage)
    {
        Print(requestMessage);
        return ReadUserInput();
    }

    private void Print(string message)
    {
        _notifier.Notify(message);
    }

    private string ReadUserInput()
    {
        return _inputReader.Read();
    }

    public static void CreateUser()
    {
        new SecurityManager(new ConsoleNotifier(), new ConsoleInputReader()).CreateValidUser();
    }
}