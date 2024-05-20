using MarsRover.Tests.helpers;

namespace MarsRover.Tests.communicationProtocols;

public class RoverUsingNasaCommunicationProtocolTest : RoverUsingCommunicationProtocolTest
{
    protected override RoverBuilder GetRoverBuilder()
    {
        return RoverBuilder.NasaRover();
    }

    protected override string GetForwardCommandRepresentation()
    {
        return "f";
    }

    protected override string GetBackwardCommandRepresentation()
    {
        return "b";
    }

    protected override string GetRotateRightCommandRepresentation()
    {
        return "r";
    }

    protected override string GetRotateLeftCommandRepresentation()
    {
        return "l";
    }
}