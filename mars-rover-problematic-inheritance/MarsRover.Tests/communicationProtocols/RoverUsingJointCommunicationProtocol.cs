using NUnit.Framework;
using static MarsRover.Tests.helpers.RoverBuilder;

namespace MarsRover.Tests.communicationProtocols;

public class RoverUsingJointCommunicationProtocol
{
    [Test]
    public void empty_sequence()
    {
        var rover = JointRover().Build();

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(JointRover().Build()));
    }

    [Test]
    public void Using_Esa_Protocol()
    {
        var rover = JointRover().WithCoordinates(1, 1).Facing("N").Build();

        rover.Receive("*b");

        Assert.That(rover, Is.EqualTo(JointRover().WithCoordinates(1, 2).Facing("N").Build()));
    }

    [Test]
    public void Using_Cnsa_Protocol()
    {
        var rover = JointRover().Facing("N").Build();

        rover.Receive("%pl");

        Assert.That(rover, Is.EqualTo(JointRover().Facing("E").Build()));
    }

    [Test]
    public void Using_Nasa_Protocol()
    {
        var rover = JointRover().WithCoordinates(3, 4).Facing("W").Build();

        rover.Receive("$b");

        Assert.That(rover, Is.EqualTo(JointRover().WithCoordinates(4, 4).Facing("W").Build()));
    }

    [Test]
    public void Using_Jaxa_Protocol()
    {
        var rover = JointRover().Facing("S").Build();

        rover.Receive("+iz");

        Assert.That(rover, Is.EqualTo(JointRover().Facing("E").Build()));
    }

    [Test]
    public void Unknown_Protocol_Ignore_Command_Sequence()
    {
        var rover = JointRover().Build();

        rover.Receive(";iz");

        Assert.That(rover, Is.EqualTo(JointRover().Build()));
    }
}