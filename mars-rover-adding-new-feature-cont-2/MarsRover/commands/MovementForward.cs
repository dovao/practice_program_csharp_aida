namespace MarsRover.commands;

public class MovementForward : Command
{
    private readonly int _displacement;

    public MovementForward(int displacement)
    {
        _displacement = displacement;
    }

    public Location Execute(Location location)
    {
        return location.Move(_displacement);
    }
}