using System.Collections.Generic;
using MarsRover.communicationProtocols;
using MarsRover.communicationProtocols.commandExtractors;
using NUnit.Framework;

namespace MarsRover.Tests.communicationProtocols.commandExtractors;

public class JaxaCommandExtractorTest
{
    private CommandExtractor _commandExtractor;

    [SetUp]
    public void SetUp()
    {
        _commandExtractor = new JaxaCommandExtractor();
    }

    [Test]
    public void extract_from_empty_sequence()
    {
        var result = _commandExtractor.Extract("");

        Assert.That(result, Is.EqualTo(new List<string>()));
    }

    [TestCase("at")]
    [TestCase("iz")]
    [TestCase("del")]
    [TestCase("der")]
    public void extract_from_sequence_with_one_jaxa_command(string command)
    {
        var result = _commandExtractor.Extract(command);

        Assert.That(result, Is.EqualTo(new List<string> { command }));
    }

    [Test]
    public void extract_from_sequence_with_not_jaxa_commands()
    {
        var result = _commandExtractor.Extract("a");

        Assert.That(result, Is.EqualTo(new List<string>()));
    }

    [Test]
    public void extract_from_sequence_with_one_jaxa_invalid_command()
    {
        var result = _commandExtractor.Extract("ab");

        Assert.That(result, Is.EqualTo(new List<string>()));
    }

    [Test]
    public void extract_from_sequence_with_two_jaxa_commands()
    {
        var result = _commandExtractor.Extract("atdel");

        Assert.That(result, Is.EqualTo(new List<string> { "at", "del" }));
    }

    [Test]
    public void extract_from_sequence_with_one_jaxa_command_and_trash()
    {
        var result = _commandExtractor.Extract("dela");

        Assert.That(result, Is.EqualTo(new List<string> { "del" }));
    }

    [Test]
    public void extract_from_sequence_with_one_jaxa_command_and_trash_at_the_middle()
    {
        var result = _commandExtractor.Extract("atdelader");

        Assert.That(result, Is.EqualTo(new List<string> { "at", "del" }));
    }

    [Test]
    public void extract_from_sequence_with_one_jaxa_command_and_trash_at_the_beginning()
    {
        var result = _commandExtractor.Extract("adel");

        Assert.That(result, Is.EqualTo(new List<string>()));
    }
}