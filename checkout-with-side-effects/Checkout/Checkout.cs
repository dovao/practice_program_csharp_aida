namespace Checkout;

public class Checkout
{
    public Receipt CreateReceipt(Money amount)
    {
        var vat = amount.Percentage(20);

        var receipt = new Receipt(amount, vat, amount.Add(vat));

        ReceiptRepository.Store(receipt);

        return receipt;
    }
}