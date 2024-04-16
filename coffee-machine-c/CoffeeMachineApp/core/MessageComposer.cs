namespace CoffeeMachineApp.core;

public interface MessageComposer
{
    Message ComposeMissingMoneyMessage(decimal missingMoney);
    Message ComposeSelectDrinkMessage();
}