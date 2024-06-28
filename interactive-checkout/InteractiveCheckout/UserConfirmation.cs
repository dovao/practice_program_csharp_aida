namespace InteractiveCheckout;

public class UserConfirmation
{
    private readonly bool _accepted;

    public UserConfirmation(string message)
    {
        Console.WriteLine($"{message} Choose Option (Y yes) (N no):");
        var result = Console.ReadLine();
        _accepted = result != null && result.ToLower() == "y";
    }

    public bool WasAccepted()
    {
        return _accepted;
    }
}