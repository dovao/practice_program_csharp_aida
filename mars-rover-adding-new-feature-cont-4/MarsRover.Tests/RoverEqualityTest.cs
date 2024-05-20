using NUnit.Framework;
using static MarsRover.Tests.helpers.RoverBuilder;

namespace MarsRover.Tests;

public class RoverEqualityTest
{
    [Test]
    public void Equal_Rovers()
    {
        Assert.That(NasaRover().Build(), Is.EqualTo(NasaRover().Build()));
    }

    [Test]
    public void Not_Equal_Rovers()
    {
        Assert.That(NasaRover().Facing("N").Build(), Is.Not.EqualTo(NasaRover().Facing("S").Build()));
        Assert.That(NasaRover().WithCoordinates(1, 1).Build(),
            Is.Not.EqualTo(NasaRover().WithCoordinates(1, 2).Build()));
        Assert.That(NasaRover().WithCoordinates(0, 1).Build(),
            Is.Not.EqualTo(NasaRover().WithCoordinates(2, 1).Build()));
    }
}