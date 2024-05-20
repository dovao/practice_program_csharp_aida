using MarsRover.Tests.helpers;
using static MarsRover.Tests.helpers.RoverBuilder;

namespace MarsRover.Tests.communicationProtocols;

public class RoverUsingJaxaCommunicationProtocolTest : RoverUsingCommunicationProtocolTest
{
    protected override RoverBuilder GetRoverBuilder()
    {
        return JaxaRover();
    }

    protected override string GetForwardCommandRepresentation()
    {
        return "del";
    }

    protected override string GetBackwardCommandRepresentation()
    {
        return "at";
    }

    protected override string GetRotateRightCommandRepresentation()
    {
        return "der";
    }

    protected override string GetRotateLeftCommandRepresentation()
    {
        return "iz";
    }
}