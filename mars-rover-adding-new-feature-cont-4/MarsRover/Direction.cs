namespace MarsRover;

public abstract record Direction
{
    internal static Direction CreateEast()
    {
        return new East();
    }

    internal static Direction CreateWest()
    {
        return new West();
    }

    internal static Direction CreateSouth()
    {
        return new South();
    }

    internal static Direction CreateNorth()
    {
        return new North();
    }

    public abstract Direction RotateLeft();

    public abstract Direction RotateRight();

    public abstract Coordinates Move(Coordinates coordinates, int displacement);

    private record East : Direction
    {
        public override Direction RotateLeft()
        {
            return CreateNorth();
        }

        public override Direction RotateRight()
        {
            return CreateSouth();
        }

        public override Coordinates Move(Coordinates coordinates, int displacement)
        {
            return coordinates.MoveAlongXAxis(displacement);
        }
    }

    private record West : Direction
    {
        public override Direction RotateLeft()
        {
            return CreateSouth();
        }

        public override Direction RotateRight()
        {
            return CreateNorth();
        }

        public override Coordinates Move(Coordinates coordinates, int displacement)
        {
            return coordinates.MoveAlongXAxis(-displacement);
        }
    }

    private record South : Direction
    {
        public override Direction RotateLeft()
        {
            return CreateEast();
        }

        public override Direction RotateRight()
        {
            return CreateWest();
        }

        public override Coordinates Move(Coordinates coordinates, int displacement)
        {
            return coordinates.MoveAlongYAxis(-displacement);
        }
    }

    private record North : Direction
    {
        public override Direction RotateLeft()
        {
            return CreateWest();
        }

        public override Direction RotateRight()
        {
            return CreateEast();
        }

        public override Coordinates Move(Coordinates coordinates, int displacement)
        {
            return coordinates.MoveAlongYAxis(displacement);
        }
    }
}