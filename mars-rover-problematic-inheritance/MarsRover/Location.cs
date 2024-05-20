using System;

namespace MarsRover;

public class Location
{
    private readonly Coordinates _coordinates;
    private readonly Direction _direction;

    public Location(Direction direction, Coordinates coordinates)
    {
        _direction = direction;
        _coordinates = coordinates;
    }

    public Location RotateLeft()
    {
        return new Location(_direction.RotateLeft(), _coordinates);
    }

    public Location RotateRight()
    {
        return new Location(_direction.RotateRight(), _coordinates);
    }

    public Location Move(int displacement)
    {
        return new Location(_direction, _direction.Move(_coordinates, displacement));
    }

    protected bool Equals(Location other)
    {
        return Equals(_direction, other._direction) && Equals(_coordinates, other._coordinates);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Location)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_direction, _coordinates);
    }

    public override string ToString()
    {
        return $"{nameof(_direction)}: {_direction}, {nameof(_coordinates)}: {_coordinates}";
    }
}