namespace MarsRover;

public interface Command
{
    public Location Execute(Location location);
}