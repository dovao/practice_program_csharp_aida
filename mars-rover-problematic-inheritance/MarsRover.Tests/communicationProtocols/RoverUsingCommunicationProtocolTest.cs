using MarsRover.Tests.helpers;
using NUnit.Framework;

namespace MarsRover.Tests.communicationProtocols;

public abstract class RoverUsingCommunicationProtocolTest
{
    protected abstract RoverBuilder GetRoverBuilder();
    protected abstract string GetForwardCommandRepresentation();
    protected abstract string GetBackwardCommandRepresentation();
    protected abstract string GetRotateRightCommandRepresentation();
    protected abstract string GetRotateLeftCommandRepresentation();

    [Test]
    public void No_Commands()
    {
        var rover = GetRoverBuilder().Build();

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(GetRoverBuilder().Build()));
    }

    [Test]
    public void Forward_Commands()
    {
        var rover = GetRoverBuilder().WithCoordinates(0, 0).Facing("N").Build();

        rover.Receive(GetForwardCommandRepresentation());

        Assert.That(rover, Is.EqualTo(GetRoverBuilder().WithCoordinates(0, 1).Facing("N").Build()));
    }

    [Test]
    public void Backward_Commands()
    {
        var rover = GetRoverBuilder().WithCoordinates(3, 3).Facing("E").Build();

        rover.Receive(GetBackwardCommandRepresentation());

        Assert.That(rover, Is.EqualTo(GetRoverBuilder().WithCoordinates(2, 3).Facing("E").Build()));
    }

    [Test]
    public void Rotate_Left_Commands()
    {
        var rover = GetRoverBuilder().Facing("E").Build();

        rover.Receive(GetRotateLeftCommandRepresentation());

        Assert.That(rover, Is.EqualTo(GetRoverBuilder().Facing("N").Build()));
    }

    [Test]
    public void Rotate_Right_Commands()
    {
        var rover = GetRoverBuilder().Facing("W").Build();

        rover.Receive(GetRotateRightCommandRepresentation());

        Assert.That(rover, Is.EqualTo(GetRoverBuilder().Facing("N").Build()));
    }

    [Test]
    public void Several_Commands()
    {
        var rover = GetRoverBuilder().WithCoordinates(2, 2).Facing("W").Build();

        rover.Receive(GetForwardCommandRepresentation() + GetRotateLeftCommandRepresentation() +
                      GetRotateRightCommandRepresentation() + GetBackwardCommandRepresentation());

        Assert.That(rover, Is.EqualTo(GetRoverBuilder().WithCoordinates(2, 2).Facing("W").Build()));
    }
}