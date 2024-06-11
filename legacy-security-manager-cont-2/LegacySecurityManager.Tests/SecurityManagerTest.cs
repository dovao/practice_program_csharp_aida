using NSubstitute;
using NUnit.Framework;

namespace LegacySecurityManager.Tests;

public class SecurityManagerTest
{
    private Notifier _notifier;
    private SecurityManager _securityManager;
    private UserDataRequester _userDataRequester;

    [SetUp]
    public void Setup()
    {
        _notifier = Substitute.For<Notifier>();
        _userDataRequester = Substitute.For<UserDataRequester>();
        _securityManager = new SecurityManager(_notifier, _userDataRequester);
    }

    [Test]
    public void do_not_save_user_when_password_and_confirm_password_are_not_equals()
    {
        _userDataRequester.Request().Returns(new UserData("username", "fullName", "Pepe1234", "Pepe1234."));

        _securityManager.CreateValidUser();

        _notifier.Received(1).Notify("The passwords don't match");
    }

    [Test]
    public void do_not_save_user_when_password_too_short()
    {
        _userDataRequester.Request().Returns(new UserData("username", "fullName", "Pepe123", "Pepe123"));

        _securityManager.CreateValidUser();

        _notifier.Received(1).Notify("Password must be at least 8 characters in length");
    }

    [Test]
    public void save_user()
    {
        _userDataRequester.Request().Returns(new UserData("username", "fullName", "Pepe1234", "Pepe1234"));

        _securityManager.CreateValidUser();

        var reversedPassword = "4321epeP";
        _notifier.Received(1).Notify($"Saving Details for User (username, fullName, {reversedPassword})\n");
    }
}