namespace CoffeeMachineApp.core;

public interface Notifier
{
    void NotifyMissingPrice(decimal missingPrice);
    void NotifySelectDrink();
}