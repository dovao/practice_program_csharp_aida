namespace InteractiveCheckout;

public class Product
{
    private readonly string _name;

    public Product(string name)
    {
        _name = name;
    }

    public override string ToString()
    {
        return GetName();
    }

    public string GetName()
    {
        return _name;
    }
}