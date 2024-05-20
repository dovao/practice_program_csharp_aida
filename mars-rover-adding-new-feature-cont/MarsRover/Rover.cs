using System.Collections.Generic;

namespace MarsRover;

public class Rover
{
    private const int Displacement = 1;
    private readonly NasaCommunicationProtocol _communicationProtocol;
    private Location _location;

    public Rover(int x, int y, string direction)
    {
        _location = new Location(DirectionMapper.Create(direction), new Coordinates(x, y));
        _communicationProtocol = new NasaCommunicationProtocol();
    }

    public void Receive(string commandsSequence)
    {
        var commands = _communicationProtocol.CreateCommands(commandsSequence, Displacement);
        Execute(commands);
    }

    private void Execute(List<Command> commands)
    {
        foreach (var command in commands) _location = command.Execute(_location);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Rover)obj);
    }

    protected bool Equals(Rover other)
    {
        return Equals(_location, other._location);
    }

    public override int GetHashCode()
    {
        return _location != null ? _location.GetHashCode() : 0;
    }

    public override string ToString()
    {
        return $"{nameof(_location)}: {_location}";
    }
}