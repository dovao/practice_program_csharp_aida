using NSubstitute;
using NUnit.Framework;

namespace LegacySecurityManager.Tests;

public class SecurityManagerTest
{
    private const string Username = "Pepe";
    private const string FullName = "Pepe Garcia";
    private Notifier _notifier;
    private InputReader _reader;
    private SecurityManager _securityManager;

    [SetUp]
    public void Setup()
    {
        _notifier = Substitute.For<Notifier>();
        _reader = Substitute.For<InputReader>();
        _securityManager = new SecurityManager(_notifier, _reader);
    }

    [Test]
    public void do_not_save_user_when_password_and_confirm_password_are_not_equals()
    {
        IntroducingPasswords("Pepe1234", "Pepe1234.");

        CreateUser();

        VerifyNotifiedMessages("The passwords don't match");
    }

    [Test]
    public void do_not_save_user_when_password_too_short()
    {
        IntroducingPasswords("Pepe123", "Pepe123");

        CreateUser();

        VerifyNotifiedMessages("Password must be at least 8 characters in length");
    }

    [Test]
    public void save_user()
    {
        var validPassword = "Pepe1234";
        IntroducingPasswords(validPassword, validPassword);

        CreateUser();

        var reversedPassword = "4321epeP";
        VerifyNotifiedMessages($"Saving Details for User ({Username}, {FullName}, {reversedPassword})\n");
    }

    private void CreateUser()
    {
        _securityManager.CreateValidUser();
    }

    private void IntroducingPasswords(string password, string confirmedPassword)
    {
        _reader.Read().Returns(Username, FullName, password, confirmedPassword);
    }

    private void VerifyNotifiedMessages(string lastMessage)
    {
        Received.InOrder(() =>
        {
            _notifier.Received(1).Notify("Enter a username");
            _notifier.Received(1).Notify("Enter your full name");
            _notifier.Received(1).Notify("Enter your password");
            _notifier.Received(1).Notify("Re-enter your password");
            _notifier.Received(1).Notify(lastMessage);
        });
        _notifier.Received(5).Notify(Arg.Any<string>());
    }
}