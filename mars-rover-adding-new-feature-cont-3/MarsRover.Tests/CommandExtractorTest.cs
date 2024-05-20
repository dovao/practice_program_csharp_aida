using System.Collections.Generic;
using MarsRover.communicationProtocols;
using NUnit.Framework;

namespace MarsRover.Tests;

[TestFixture]
public class CommandExtractorTest
{

    [Test]
    public void extract_commands_with_length_one()
    {
        var commandExtractor = CreateCommandExtractorForCommandsOfSize(1);

        var result = commandExtractor.Extract("abc");

        Assert.That(result, Is.EqualTo(new List<string> { "a", "b", "c" }));
    }

    [Test]
    public void extract_commands_with_length_two()
    {
        var commandExtractor = CreateCommandExtractorForCommandsOfSize(2);

        var result = commandExtractor.Extract("abc");

        Assert.That(result, Is.EqualTo(new List<string> { "ab", "c" }));
    }

    private static CommandExtractor CreateCommandExtractorForCommandsOfSize(uint size)
    {
        return new CommandExtractor(size);
    }
}