namespace ShoppingCart;

public class ShoppingCart
{
    private readonly ProductsRepository _productsRepository;
    private readonly Notifier _notifier;
    private readonly CheckoutService _checkoutService;
    private readonly DiscountsRepository _discountsRepository;
    private readonly Display _display;
    private Discount _discount;
    private CartProducts _cartProducts;

    public ShoppingCart(ProductsRepository productsRepository, Notifier notifier, CheckoutService checkoutService, 
        DiscountsRepository discountsRepository, Display display)
    {
        _productsRepository = productsRepository;
        _notifier = notifier;
        _checkoutService = checkoutService;
        _discountsRepository = discountsRepository;
        _display = display;
        InitializeState();
    }

    public void AddItem(string productName)
    {
        var product = _productsRepository.Get(productName);
        if (product is null)
        {
            _notifier.ShowError("Product is not available");
            return;
        }
        _cartProducts.Add(product);
    }

    public void ApplyDiscount(DiscountCode discountCode)
    {
        var discount = _discountsRepository.Get(discountCode);
        if (discount is null)
        {
            _notifier.ShowError("Discount is not available");
            return;
        }
        _discount = discount;
    }

    public void Checkout()
    {
        if (_cartProducts.ThereAreNoProducts())
        {
            NotifyEmptyShoppingCart();
            return;
        }
        PerformCheckout();
        InitializeState();
    }

    public void Display()
    {
        var contentsSummary = _cartProducts.CreateContentsSummary();
        _display.Show(contentsSummary);
    }

    private void InitializeState()
    {
        _discount = new Discount(DiscountCode.None, 0);
        _cartProducts = new CartProducts();
    }

    private void NotifyEmptyShoppingCart()
    {
        _notifier.ShowError("No product selected, please select a product");
    }

    private void PerformCheckout()
    {
        var totalCost = ComputeTotalCost();
        var shoppingCartDto = new ShoppingCartDto(totalCost);
        _checkoutService.Checkout(shoppingCartDto);
    }

    private decimal ComputeTotalCost()
    {
        var totalCost = _cartProducts.ComputeAllProductsCost();
        return _discount.Apply(totalCost);
    }
}