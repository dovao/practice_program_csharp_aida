namespace ShoppingCart;

public class ShoppingCartSummaryItem {
    public int Quantity { get; }
    public string Name { get; }
    public decimal TotalCost { get; }
    
    public ShoppingCartSummaryItem(string name, int quantity, decimal totalCost)
    {
        Name = name;
        Quantity = quantity;
        TotalCost = totalCost;
    }
}
