using NUnit.Framework;
using static MarsRover.Tests.helpers.RoverBuilder;

namespace MarsRover.Tests;

public class RoverUsingEsaCommunicationProtocolTest
{
    [Test]
    public void No_Commands()
    {
        var rover = EsaRover().Build();

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(EsaRover().Build()));
    }

    [Test]
    public void Forward_Commands()
    {
        var rover = EsaRover().WithCoordinates(0, 0).Facing("N").Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(EsaRover().WithCoordinates(0, 1).Facing("N").Build()));
    }

    [Test]
    public void Backward_Commands()
    {
        var rover = EsaRover().WithCoordinates(3, 3).Facing("E").Build();

        rover.Receive("x");

        Assert.That(rover, Is.EqualTo(EsaRover().WithCoordinates(2, 3).Facing("E").Build()));
    }

    [Test]
    public void Rotate_Left_Commands()
    {
        var rover = EsaRover().Facing("E").Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(EsaRover().Facing("N").Build()));
    }

    [Test]
    public void Rotate_Right_Commands()
    {
        var rover = EsaRover().Facing("W").Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(EsaRover().Facing("N").Build()));
    }

    [Test]
    public void Two_Commands()
    {
        var rover = EsaRover().Facing("W").Build();

        rover.Receive("lf");

        Assert.That(rover, Is.EqualTo(EsaRover().Facing("W").Build()));
    }
}