using MarsRover.Tests.helpers;
using static MarsRover.Tests.helpers.RoverBuilder;

namespace MarsRover.Tests.communicationProtocols;

public class RoverUsingEsaCommunicationProtocolTest : RoverUsingCommunicationProtocolTest
{
    protected override RoverBuilder GetRoverBuilder()
    {
        return EsaRover();
    }

    protected override string GetForwardCommandRepresentation()
    {
        return "b";
    }

    protected override string GetBackwardCommandRepresentation()
    {
        return "x";
    }

    protected override string GetRotateRightCommandRepresentation()
    {
        return "l";
    }

    protected override string GetRotateLeftCommandRepresentation()
    {
        return "f";
    }
}