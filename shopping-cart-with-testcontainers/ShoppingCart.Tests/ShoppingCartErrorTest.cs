using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using static ShoppingCart.Tests.ProductBuilder;
using static ShoppingCart.Tests.ShoppingCartTestHelpers;

namespace ShoppingCart.Tests;

public class ShoppingCartErrorTest
{
    private const string Iceberg = "Iceberg";
    private ProductsRepository _productsRepository;
    private Notifier _notifier;
    private ShoppingCart _shoppingCart;
    private CheckoutService _checkoutService;
    private DiscountsRepository _discountsRepository;

    [SetUp]
    public void SetUp()
    {
        _productsRepository = Substitute.For<ProductsRepository>();
        _notifier = Substitute.For<Notifier>();
        _checkoutService = Substitute.For<CheckoutService>();
        _discountsRepository = Substitute.For<DiscountsRepository>();
        _shoppingCart = CreateShoppingCartForCheckout(_productsRepository, _notifier, _checkoutService, _discountsRepository);
    }

    [Test]
    public void adding_not_available_product_fails()
    {
        const string notAvailableProductName = "some_item";
        _productsRepository.Get(notAvailableProductName).ReturnsNull();

        _shoppingCart.AddItem(notAvailableProductName);

        _notifier.Received(1).ShowError("Product is not available");
    }

    [Test]
    public void applying_not_available_discount_fails()
    {
        var notAvailableDiscount = DiscountCode.PROMO_20;
        _discountsRepository.Get(notAvailableDiscount).ReturnsNull();

        _shoppingCart.ApplyDiscount(notAvailableDiscount);

        _notifier.Received(1).ShowError("Discount is not available");
    }

    [Test]
    public void checking_out_without_products_fails()
    {
        _shoppingCart.Checkout();

        _notifier.Received(1).ShowError("No product selected, please select a product");
    }

    [Test]
    public void checking_out_several_times_fails()
    {
        _productsRepository.Get(Iceberg).Returns(
            TaxFreeWithNoRevenueProduct().Named(Iceberg).Costing(1m).Build());

        _shoppingCart.AddItem(Iceberg);
        _shoppingCart.Checkout();
        _shoppingCart.Checkout();

        _checkoutService.Received(1).Checkout(CreateShoppingCartDto(1));
        _notifier.Received(1).ShowError("No product selected, please select a product");
    }
}