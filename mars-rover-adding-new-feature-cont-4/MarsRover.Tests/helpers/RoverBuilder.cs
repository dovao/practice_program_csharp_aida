using MarsRover.communicationProtocols;

namespace MarsRover.Tests.helpers;

public class RoverBuilder
{
    private readonly CommunicationProtocol _communicationProtocol;
    private string _direction;
    private int _x;
    private int _y;

    private RoverBuilder(int x, int y, string direction, CommunicationProtocol communicationProtocol)
    {
        _x = x;
        _y = y;
        _direction = direction;
        _communicationProtocol = communicationProtocol;
    }

    public Rover Build()
    {
        return new Rover(_x, _y, _direction, _communicationProtocol);
    }

    public RoverBuilder Facing(string direction)
    {
        _direction = direction;
        return this;
    }

    public RoverBuilder WithCoordinates(int x, int y)
    {
        _x = x;
        _y = y;
        return this;
    }

    public static RoverBuilder NasaRover()
    {
        return new RoverBuilder(1, 0, "N", new NasaCommunicationProtocol());
    }

    public static RoverBuilder EsaRover()
    {
        return new RoverBuilder(0, 2, "N", new EsaCommunicationProtocol());
    }

    public static RoverBuilder CsnaRover()
    {
        return new RoverBuilder(3, 0, "N", new CnsaCommunicationProtocol());
    }

    public static RoverBuilder JaxaRover()
    {
        return new RoverBuilder(1, 1, "N", new JaxaCommunicationProtocol());
    }
}