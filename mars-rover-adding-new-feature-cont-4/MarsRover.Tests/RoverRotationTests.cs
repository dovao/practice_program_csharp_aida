using NUnit.Framework;
using static MarsRover.Tests.helpers.RoverBuilder;

namespace MarsRover.Tests;

public class RoverRotationTests
{
    [Test]
    public void Facing_North_Rotate_Left()
    {
        var rover = NasaRover().Facing("N").Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(NasaRover().Facing("W").Build()));
    }

    [Test]
    public void Facing_North_Rotate_Right()
    {
        var rover = NasaRover().Facing("N").Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(NasaRover().Facing("E").Build()));
    }

    [Test]
    public void Facing_South_Rotate_Left()
    {
        var rover = NasaRover().Facing("S").Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(NasaRover().Facing("E").Build()));
    }

    [Test]
    public void Facing_South_Rotate_Right()
    {
        var rover = NasaRover().Facing("S").Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(NasaRover().Facing("W").Build()));
    }

    [Test]
    public void Facing_West_Rotate_Left()
    {
        var rover = NasaRover().Facing("W").Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(NasaRover().Facing("S").Build()));
    }

    [Test]
    public void Facing_West_Rotate_Right()
    {
        var rover = NasaRover().Facing("W").Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(NasaRover().Facing("N").Build()));
    }

    [Test]
    public void Facing_East_Rotate_Left()
    {
        var rover = NasaRover().Facing("E").Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(NasaRover().Facing("N").Build()));
    }

    [Test]
    public void Facing_East_Rotate_Right()
    {
        var rover = NasaRover().Facing("E").Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(NasaRover().Facing("S").Build()));
    }
}