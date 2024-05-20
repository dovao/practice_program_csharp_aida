namespace MarsRover;

internal static class DirectionMapper
{
    private const string North = "N";
    private const string South = "S";
    private const string West = "W";

    public static Direction Create(string directionEncoding)
    {
        switch (directionEncoding)
        {
            case North:
                return Direction.CreateNorth();
            case South:
                return Direction.CreateSouth();
            case West:
                return Direction.CreateWest();
            default:
                return Direction.CreateEast();
        }
    }
}