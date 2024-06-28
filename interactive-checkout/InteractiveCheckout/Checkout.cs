namespace InteractiveCheckout;

public class Checkout
{
    private readonly IEmailService _emailService;

    private readonly UserConfirmation _newsLetterSubscribed;
    private readonly Product _product;

    private readonly UserConfirmation _termsAndConditionsAccepted;

    public Checkout(Product product, IEmailService emailService)
    {
        _product = product;
        _emailService = emailService;
        _newsLetterSubscribed = new UserConfirmation("Subscribe to our product " + product + " newsletter?");
        _termsAndConditionsAccepted = new UserConfirmation(
            "Accept our terms and conditions?\n" + //
            "(Mandatory to place order for " + product + ")");
    }

    public void ConfirmOrder()
    {
        if (!_termsAndConditionsAccepted.WasAccepted()) throw new OrderCancelledException(_product);
        if (_newsLetterSubscribed.WasAccepted()) _emailService.SubscribeUserFor(_product);
    }
}
