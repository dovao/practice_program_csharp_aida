using NSubstitute;
using NUnit.Framework;

namespace LegacySecurityManager.Tests;

public class ConsoleUserDataRequesterTest
{
    private Input _input;
    private ConsoleUserDataRequester _userRequest;

    [SetUp]
    public void SetUp()
    {
        _input = Substitute.For<Input>();
        _userRequest = new ConsoleUserDataRequester(_input);
    }

    [Test]
    public void request_user_data()
    {
        const string username = "username";
        const string fullName = "fullname";
        const string password = "password";
        const string confirmPassword = "confirmationPassword";
        InputByConsole(username, fullName, password, confirmPassword);

        var userData = _userRequest.Request();

        Assert.That(userData, Is.EqualTo(new UserData(username, fullName, password, confirmPassword)));
    }

    private void InputByConsole(string username, string fullName, string password, string confirmPassword)
    {
        _input.Request("Enter a username").Returns(username);
        _input.Request("Enter your full name").Returns(fullName);
        _input.Request("Enter your password").Returns(password);
        _input.Request("Re-enter your password").Returns(confirmPassword);
    }
}