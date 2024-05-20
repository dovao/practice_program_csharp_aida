using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverPositionTests
{
    [Test]
    public void Facing_North_Move_Forward()
    {
        var rover = ANASARover().WithCoordinates(0, 0).Facing("N").Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ANASARover().WithCoordinates(0, 1).Facing("N").Build()));
    }

    [Test]
    public void Facing_North_Move_Backward()
    {
        var rover = ANASARover().WithCoordinates(0, 0).Facing("N").Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ANASARover().WithCoordinates(0, -1).Facing("N").Build()));
    }

    [Test]
    public void Facing_South_Move_Forward()
    {
        var rover = ANASARover().WithCoordinates(0, 0).Facing("S").Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ANASARover().WithCoordinates(0, -1).Facing("S").Build()));
    }

    [Test]
    public void Facing_South_Move_Backward()
    {
        var rover = ANASARover().WithCoordinates(0, 0).Facing("S").Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ANASARover().WithCoordinates(0, 1).Facing("S").Build()));
    }

    [Test]
    public void Facing_West_Move_Forward()
    {
        var rover = ANASARover().WithCoordinates(0, 0).Facing("W").Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ANASARover().WithCoordinates(-1, 0).Facing("W").Build()));
    }

    [Test]
    public void Facing_West_Move_Backward()
    {
        var rover = ANASARover().WithCoordinates(0, 0).Facing("W").Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ANASARover().WithCoordinates(1, 0).Facing("W").Build()));
    }

    [Test]
    public void Facing_East_Move_Forward()
    {
        var rover = ANASARover().WithCoordinates(2, 4).Facing("E").Build();

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(ANASARover().WithCoordinates(3, 4).Facing("E").Build()));
    }

    [Test]
    public void Facing_East_Move_Backward()
    {
        var rover = ANASARover().WithCoordinates(2, 4).Facing("E").Build();

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(ANASARover().WithCoordinates(1, 4).Facing("E").Build()));
    }
}