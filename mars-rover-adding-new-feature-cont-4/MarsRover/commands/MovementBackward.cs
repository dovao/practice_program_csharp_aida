namespace MarsRover.commands;

public class MovementBackward : Command
{
    private readonly int _displacement;

    public MovementBackward(int displacement)
    {
        _displacement = displacement;
    }

    public Location Execute(Location location)
    {
        return location.Move(-_displacement);
    }
}