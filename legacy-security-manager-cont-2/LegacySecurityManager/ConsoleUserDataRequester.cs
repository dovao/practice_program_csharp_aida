namespace LegacySecurityManager;

public class ConsoleUserDataRequester : UserDataRequester {
    private Input input;

    public ConsoleUserDataRequester(Input input) {
        this.input = input;
    }
    public UserData Request() {

        return new UserData(RequestUserName(), RequestFullName(), RequestPassword(), RequestPasswordConfirmation());
    }

    private string RequestPasswordConfirmation()
    {
        return input.Request("Re-enter your password");
    }

    private string RequestPassword()
    {
        return input.Request("Enter your password");
    }

    private string RequestFullName()
    {
        return input.Request("Enter your full name");
    }

    private string RequestUserName()
    {
        return input.Request("Enter a username");
    }

}