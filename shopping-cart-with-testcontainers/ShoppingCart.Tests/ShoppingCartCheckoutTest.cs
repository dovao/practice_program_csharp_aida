using NSubstitute;
using NUnit.Framework;
using static ShoppingCart.Tests.ProductBuilder;
using static ShoppingCart.Tests.ShoppingCartTestHelpers;

namespace ShoppingCart.Tests
{
    public class ShoppingCartCheckoutTest
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
        public void checking_out_one_tax_free_product_with_no_revenue()
        {
            _productsRepository.Get(Iceberg).Returns(
                TaxFreeWithNoRevenueProduct().Named(Iceberg).Costing(1.55m).Build());

            _shoppingCart.AddItem(Iceberg);
            _shoppingCart.Checkout();

            _checkoutService.Received(1).Checkout(CreateShoppingCartDto(1.55m));
        }


        [Test]
        public void checking_out_two_tax_free_products_with_no_revenue()
        {
            const string tomato = "Tomato";
            _productsRepository.Get(Iceberg).Returns(
                TaxFreeWithNoRevenueProduct().Named(Iceberg).Costing(1.55m).Build());
            _productsRepository.Get(tomato).Returns(
                TaxFreeWithNoRevenueProduct().Named(tomato).Costing(1m).Build());

            _shoppingCart.AddItem(Iceberg);
            _shoppingCart.AddItem(tomato);
            _shoppingCart.Checkout();

            _checkoutService.Received(1).Checkout(CreateShoppingCartDto(2.55m));
        }

        [Test]
        public void checking_out_one_product_with_tax_but_no_revenue()
        {
            _productsRepository.Get(Iceberg).Returns(
                NoRevenueProduct()
                    .Named(Iceberg)
                    .WithTax(0.10m)
                    .Costing(1m)
                    .Build());

            _shoppingCart.AddItem(Iceberg);
            _shoppingCart.Checkout();

            _checkoutService.Received(1).Checkout(CreateShoppingCartDto(1.10m));
        }

        [Test]
        public void checking_out_one_product_with_revenue_but_no_taxes()
        {
            _productsRepository.Get(Iceberg).Returns(
                NoTaxProduct()
                    .Named(Iceberg)
                    .WithRevenue(0.05m)
                    .Costing(2m)
                    .Build());

            _shoppingCart.AddItem(Iceberg);
            _shoppingCart.Checkout();

            _checkoutService.Received(1).Checkout(CreateShoppingCartDto(2.10m));
        }

        [Test]
        public void checking_out_one_product_with_revenue_and_taxes()
        {
            _productsRepository.Get(Iceberg).Returns(
                AnyProduct()
                    .Named(Iceberg)
                    .WithRevenue(0.05m)
                    .WithTax(0.1m)
                    .Costing(2m)
                    .Build());

            _shoppingCart.AddItem(Iceberg);
            _shoppingCart.Checkout();

            _checkoutService.Received(1).Checkout(CreateShoppingCartDto(2.31m));
        }

        [Test]
        public void applying_discount_on_checkout()
        {
            _productsRepository.Get(Iceberg).Returns(
                TaxFreeWithNoRevenueProduct().Named(Iceberg).Costing(1.50m).Build());
            _discountsRepository.Get(DiscountCode.PROMO_5).Returns(new Discount(DiscountCode.PROMO_5, 0.5m));

            _shoppingCart.AddItem(Iceberg);
            _shoppingCart.ApplyDiscount(DiscountCode.PROMO_5);
            _shoppingCart.Checkout();

            _checkoutService.Received(1).Checkout(CreateShoppingCartDto(0.75m));
        }

        [Test]
        public void trying_to_apply_two_discount_only_applies_the_last_one()
        {
            _productsRepository.Get(Iceberg).Returns(
                TaxFreeWithNoRevenueProduct().Named(Iceberg).Costing(1m).Build());
            _discountsRepository.Get(DiscountCode.PROMO_5).Returns(new Discount(DiscountCode.PROMO_5, 0.5m));
            _discountsRepository.Get(DiscountCode.PROMO_10).Returns(new Discount(DiscountCode.PROMO_10, 0.01m));

            _shoppingCart.AddItem(Iceberg);
            _shoppingCart.ApplyDiscount(DiscountCode.PROMO_5);
            _shoppingCart.ApplyDiscount(DiscountCode.PROMO_10);
            _shoppingCart.Checkout();

            _checkoutService.Received(1).Checkout(CreateShoppingCartDto(0.99m));
        }

        [Test]
        public void checkout_total_price_is_rounded_up()
        {
            _productsRepository.Get(Iceberg).Returns(
                AnyProduct()
                    .Named(Iceberg)
                    .Costing(0.78001m)
                    .WithTax(1)
                    .WithRevenue(2)
                    .Build());
            var otherProductName = "otherProduct";
            _productsRepository.Get(otherProductName).Returns(
                TaxFreeWithNoRevenueProduct()
                    .Named(otherProductName)
                    .Costing(1)
                    .Build());

            _shoppingCart.AddItem(Iceberg);
            _shoppingCart.AddItem(otherProductName);
            _shoppingCart.ApplyDiscount(DiscountCode.PROMO_5);
            _shoppingCart.Checkout();

            _checkoutService.Received(1).Checkout(CreateShoppingCartDto(5.69m));
        }
        
        [Test]
        public void checking_out_two_units_of_one_tax_free_product_with_no_revenue()
        {
            _productsRepository.Get(Iceberg).Returns(
                TaxFreeWithNoRevenueProduct().Named(Iceberg).Costing(1.50m).Build(),
                TaxFreeWithNoRevenueProduct().Named(Iceberg).Costing(1.50m).Build());

            _shoppingCart.AddItem(Iceberg);
            _shoppingCart.AddItem(Iceberg);
            _shoppingCart.Checkout();

            _checkoutService.Received(1).Checkout(CreateShoppingCartDto(3m));
        }
    }
}