using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverRotationTests
{
    [Test]
    public void Facing_North_Rotate_Left()
    {
        var rover = ANASARover().Facing("N").Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ANASARover().Facing("W").Build()));
    }

    [Test]
    public void Facing_North_Rotate_Right()
    {
        var rover = ANASARover().Facing("N").Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ANASARover().Facing("E").Build()));
    }

    [Test]
    public void Facing_South_Rotate_Left()
    {
        var rover = ANASARover().Facing("S").Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ANASARover().Facing("E").Build()));
    }

    [Test]
    public void Facing_South_Rotate_Right()
    {
        var rover = ANASARover().Facing("S").Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ANASARover().Facing("W").Build()));
    }

    [Test]
    public void Facing_West_Rotate_Left()
    {
        var rover = ANASARover().Facing("W").Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ANASARover().Facing("S").Build()));
    }

    [Test]
    public void Facing_West_Rotate_Right()
    {
        var rover = ANASARover().Facing("W").Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ANASARover().Facing("N").Build()));
    }

    [Test]
    public void Facing_East_Rotate_Left()
    {
        var rover = ANASARover().Facing("E").Build();

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(ANASARover().Facing("N").Build()));
    }

    [Test]
    public void Facing_East_Rotate_Right()
    {
        var rover = ANASARover().Facing("E").Build();

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(ANASARover().Facing("S").Build()));
    }
}