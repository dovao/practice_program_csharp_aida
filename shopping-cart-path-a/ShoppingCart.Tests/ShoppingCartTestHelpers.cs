namespace ShoppingCart.Tests
{
    public class ShoppingCartTestHelpers
    {
        public static ShoppingCartDto CreateShoppingCartDto(decimal cost)
        {
            return new ShoppingCartDto(cost);
        }

        public static ShoppingCart CreateShoppingCartForCheckout(ProductsRepository productsRepository,
            Notifier notifier, CheckoutService checkoutService,
            DiscountsRepository discountsRepository)
        {
            return new ShoppingCart(productsRepository, notifier, checkoutService, discountsRepository, null);
        }

        public static ShoppingCart CreateShoppingCartForDisplay(ProductsRepository productsRepository, Notifier notifier,
            DiscountsRepository discountsRepository, Display display)
        {
            return new ShoppingCart(productsRepository, notifier, null, discountsRepository, display);
        }
    }
}