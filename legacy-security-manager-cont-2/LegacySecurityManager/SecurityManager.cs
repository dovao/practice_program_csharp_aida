using System;
using LegacySecurityManager.infrastructure;

namespace LegacySecurityManager;

public class SecurityManager
{
    private readonly Notifier _notifier;
    private UserDataRequester _userDataRequester;

    public SecurityManager(Notifier notifier, UserDataRequester userDataRequester)
    {
        _notifier = notifier;
        _userDataRequester = userDataRequester;
    }

    public void CreateValidUser()
    {
        var userData = _userDataRequester.Request();

        if (PasswordsDoNotMatch(userData.Password(), userData.ConfirmPassword()))
        {
            NotifyPasswordDoNotMatch();
            return;
        }

        if (IsPasswordToShort(userData.Password()))
        {
            NotifyPasswordIsToShort();
            return;
        }

        var encryptedPassword = EncryptPassword(userData.Password());
        NotifyUserCreation(userData.UserName(), userData.FullName(), encryptedPassword);
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

    private void Print(string message)
    {
        _notifier.Notify(message);
    }

    public static void CreateUser() {
        Notifier notifier = new ConsoleNotifier();
        new SecurityManager(notifier, new ConsoleUserDataRequester(new ConsoleInput())).CreateValidUser();
    }
}