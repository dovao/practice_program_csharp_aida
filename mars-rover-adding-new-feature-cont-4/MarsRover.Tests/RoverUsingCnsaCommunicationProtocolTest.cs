using MarsRover.Tests.helpers;
using static MarsRover.Tests.helpers.RoverBuilder;

namespace MarsRover.Tests;

public class RoverUsingCnsaCommunicationProtocolTest : RoverUsingCommunicationProtocolTest
{
    protected override RoverBuilder GetRoverBuilder()
    {
        return CsnaRover();
    }

    protected override string GetForwardCommandRepresentation()
    {
        return "bx";
    }

    protected override string GetBackwardCommandRepresentation()
    {
        return "tf";
    }

    protected override string GetRotateRightCommandRepresentation()
    {
        return "pl";
    }

    protected override string GetRotateLeftCommandRepresentation()
    {
        return "ah";
    }
}