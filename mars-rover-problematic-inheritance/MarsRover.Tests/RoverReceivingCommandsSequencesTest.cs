using NUnit.Framework;
using static MarsRover.Tests.helpers.RoverBuilder;

namespace MarsRover.Tests;

public class RoverReceivingCommandsSequencesTest
{
    [Test]
    public void No_Commands()
    {
        var rover = NasaRover().Build();

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(NasaRover().Build()));
    }

    [Test]
    public void Two_Commands()
    {
        var rover = NasaRover().WithCoordinates(0, 0).Facing("N").Build();

        rover.Receive("lf");

        Assert.That(rover, Is.EqualTo(NasaRover().WithCoordinates(-1, 0).Facing("W").Build()));
    }

    [Test]
    public void Many_Commands()
    {
        var rover = NasaRover().WithCoordinates(0, 0).Facing("N").Build();

        rover.Receive("ffrbbrfflff");

        Assert.That(rover, Is.EqualTo(NasaRover().WithCoordinates(0, 0).Facing("E").Build()));
    }
}