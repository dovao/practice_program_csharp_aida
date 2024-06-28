using NUnit.Framework;

namespace Checkout.Tests;

public class CheckoutTest
{
    [Test]
    public void Fix_Me()
    {
        var checkout = new Checkout();

        checkout.CreateReceipt(new Money(12));

        Assert.That(checkout, Is.Not.Null);
    }
}