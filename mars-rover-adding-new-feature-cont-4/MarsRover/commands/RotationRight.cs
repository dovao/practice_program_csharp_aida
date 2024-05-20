namespace MarsRover.commands;

public class RotationRight : Command
{
    public Location Execute(Location location)
    {
        return location.RotateRight();
    }
}