namespace ShoppingCart;

public class Discount
{
    private readonly DiscountCode _discountCode;
    private readonly decimal _amount;

    public Discount(DiscountCode discountCode, decimal amount)
    {
        _discountCode = discountCode;
        _amount = amount;
    }

    public decimal Apply(decimal totalCost)
    {
        return totalCost * (1 - _amount);
    }
}