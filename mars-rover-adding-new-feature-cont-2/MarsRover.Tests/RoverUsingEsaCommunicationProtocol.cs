using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverUsingEsaCommunicationProtocol
{
    [Test]
    public void No_Commands()
    {
        var rover = AnESARover().Build();

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(AnESARover().Build()));
    }

    [Test]
    public void Forward_Commands()
    {
        var rover = AnESARover().WithCoordinates(0, 0).Facing("N").Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(AnESARover().WithCoordinates(0, 1).Facing("N").Build()));
    }

    [Test]
    public void Backward_Commands()
    {
        var rover = AnESARover().WithCoordinates(3, 3).Facing("E").Build();

        rover.Receive("x");

        Assert.That(rover, Is.EqualTo(AnESARover().WithCoordinates(2, 3).Facing("E").Build()));
    }

    [Test]
    public void Rotate_Left_Commands()
    {
        var rover = AnESARover().Facing("E").Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(AnESARover().Facing("N").Build()));
    }

    [Test]
    public void Rotate_Right_Commands()
    {
        var rover = AnESARover().Facing("W").Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(AnESARover().Facing("N").Build()));
    }

    [Test]
    public void Two_Commands()
    {
        var rover = AnESARover().Facing("W").Build();

        rover.Receive("lf");

        Assert.That(rover, Is.EqualTo(AnESARover().Facing("W").Build()));
    }
}