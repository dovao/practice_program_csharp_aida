using NUnit.Framework;
using static MarsRover.Tests.helpers.RoverBuilder;

namespace MarsRover.Tests;

public class RoverUsingCnsaCommunicationProtocolTest
{
    [Test]
    public void No_Commands()
    {
        var rover = CsnaRover().Build();

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(CsnaRover().Build()));
    }

    [Test]
    public void Forward_Commands()
    {
        var rover = CsnaRover().WithCoordinates(0, 0).Facing("N").Build();

        rover.Receive("bx");

        Assert.That(rover, Is.EqualTo(CsnaRover().WithCoordinates(0, 1).Facing("N").Build()));
    }

    [Test]
    public void Backward_Commands()
    {
        var rover = CsnaRover().WithCoordinates(3, 3).Facing("E").Build();

        rover.Receive("tf");

        Assert.That(rover, Is.EqualTo(CsnaRover().WithCoordinates(2, 3).Facing("E").Build()));
    }

    [Test]
    public void Rotate_Left_Commands()
    {
        var rover = CsnaRover().Facing("E").Build();

        rover.Receive("ah");

        Assert.That(rover, Is.EqualTo(CsnaRover().Facing("N").Build()));
    }

    [Test]
    public void Rotate_Right_Commands()
    {
        var rover = CsnaRover().Facing("W").Build();

        rover.Receive("pl");

        Assert.That(rover, Is.EqualTo(CsnaRover().Facing("N").Build()));
    }

    [Test]
    public void Two_Commands()
    {
        var rover = CsnaRover().Facing("W").Build();

        rover.Receive("ahpl");

        Assert.That(rover, Is.EqualTo(CsnaRover().Facing("W").Build()));
    }
}