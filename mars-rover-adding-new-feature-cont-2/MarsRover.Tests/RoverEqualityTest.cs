using NUnit.Framework;
using static MarsRover.Tests.RoverBuilder;

namespace MarsRover.Tests;

public class RoverEqualityTest
{
    [Test]
    public void Equal_Rovers()
    {
        Assert.That(ANASARover().Build(), Is.EqualTo(ANASARover().Build()));
    }

    [Test]
    public void Not_Equal_Rovers()
    {
        Assert.That(ANASARover().Facing("N").Build(), Is.Not.EqualTo(ANASARover().Facing("S").Build()));
        Assert.That(ANASARover().WithCoordinates(1, 1).Build(),
            Is.Not.EqualTo(ANASARover().WithCoordinates(1, 2).Build()));
        Assert.That(ANASARover().WithCoordinates(0, 1).Build(),
            Is.Not.EqualTo(ANASARover().WithCoordinates(2, 1).Build()));
    }
}