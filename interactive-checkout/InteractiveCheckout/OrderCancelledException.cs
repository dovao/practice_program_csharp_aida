namespace InteractiveCheckout;

public class OrderCancelledException : ApplicationException
{
    public OrderCancelledException(Product product)
        : base(product.GetName())
    {
    }
}