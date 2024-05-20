namespace MarsRover.commands;

public class RotationLeft : Command
{
    public Location Execute(Location location)
    {
        return location.RotateLeft();
    }
}