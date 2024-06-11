using NSubstitute;
using NUnit.Framework;

namespace LegacySecurityManager.Tests;

public class SecurityManagerAcceptanceTest
{
    private const string Username = "Pepe";
    private const string FullName = "Pepe Garcia";
    private SecurityManager _securityManager;
    private Input _input;
    private Notifier _notifier;

    [SetUp]
    public void Setup()
    {
        _notifier = Substitute.For<Notifier>();
        _input = Substitute.For<Input>();
        _securityManager = new SecurityManager(_notifier, new ConsoleUserDataRequester(_input));
    }

    [Test]
    public void do_not_save_user_when_password_and_confirm_password_are_not_equals()
    {
        IntroducingUserDataWithPasswords("Pepe1234", "Pepe1234.");

        _securityManager.CreateValidUser();

        _notifier.Received(1).Notify("The passwords don't match");
    }

    [Test]
    public void do_not_save_user_when_password_too_short()
    {
        IntroducingUserDataWithPasswords("Pepe123", "Pepe123");

        _securityManager.CreateValidUser();

        _notifier.Received(1).Notify("Password must be at least 8 characters in length");
    }

    [Test]
    public void save_user()
    {
        var validPassword = "Pepe1234";
        IntroducingUserDataWithPasswords(validPassword, validPassword);

        _securityManager.CreateValidUser();

        var reversedPassword = "4321epeP";
        _notifier.Received(1).Notify($"Saving Details for User ({Username}, {FullName}, {reversedPassword})\n");
    }

    private void IntroducingUserDataWithPasswords(string password, string confirmedPassword)
    {
        _input.Request("Enter a username").Returns(Username);
        _input.Request("Enter your full name").Returns(FullName);
        _input.Request("Enter your password").Returns(password);
        _input.Request("Re-enter your password").Returns(confirmedPassword);
    }
}