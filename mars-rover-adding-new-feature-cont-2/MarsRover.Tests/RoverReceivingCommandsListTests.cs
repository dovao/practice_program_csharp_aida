using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverReceivingCommandsListTests
{
    [Test]
    public void No_Commands()
    {
        var rover = ANASARover().Build();

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(ANASARover().Build()));
    }

    [Test]
    public void Two_Commands()
    {
        var rover = ANASARover().WithCoordinates(0, 0).Facing("N").Build();

        rover.Receive("lf");

        Assert.That(rover, Is.EqualTo(ANASARover().WithCoordinates(-1, 0).Facing("W").Build()));
    }

    [Test]
    public void Many_Commands()
    {
        var rover = ANASARover().WithCoordinates(0, 0).Facing("N").Build();

        rover.Receive("ffrbbrfflff");

        Assert.That(rover, Is.EqualTo(ANASARover().WithCoordinates(0, 0).Facing("E").Build()));
    }
}