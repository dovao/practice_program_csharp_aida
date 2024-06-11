namespace ShoppingCart;

public interface DiscountsRepository
{
    Discount Get(DiscountCode discountCode);
}