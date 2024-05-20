namespace CoffeeMachineApp.core;

public interface DrinkMakerDriver
{
    void Send(Order order);
    void Notify(Message message);
}