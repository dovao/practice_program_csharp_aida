namespace CoffeeMachineApp.core;

public class Message
{
    private readonly string _text;

    private Message(string text)
    {
        _text = text;
    }

    public string GetText()
    {
        return _text;
    }

    public static Message Create(string message)
    {
        return new Message(message);
    }

    public override string ToString()
    {
        return $"{nameof(_text)}: {_text}";
    }

    protected bool Equals(Message other)
    {
        return _text == other._text;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Message)obj);
    }

    public override int GetHashCode()
    {
        return _text != null ? _text.GetHashCode() : 0;
    }
}