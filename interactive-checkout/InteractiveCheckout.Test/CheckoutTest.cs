using NSubstitute;

namespace InteractiveCheckout.Test;

public class CheckoutTest
{
    [Test]
    public void Test()
    {
        // note for tester:
        // Accept Newsletter
        // Do not Accept Terms

        var emailService = Substitute.For<IEmailService>();
        var polkaDotSocks = new Product("Polka-dot Socks");

        var checkout = new Checkout(polkaDotSocks, emailService);

        Assert.Throws<OrderCancelledException>(() => checkout.ConfirmOrder());
    }
}