namespace ShoppingCart;

public interface ProductsRepository
{
    Product Get(string productName);
}