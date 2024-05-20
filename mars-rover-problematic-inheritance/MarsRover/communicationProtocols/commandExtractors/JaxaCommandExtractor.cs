using System.Collections.Generic;

namespace MarsRover.communicationProtocols.commandExtractors;

public class JaxaCommandExtractor : CommandExtractor
{
    public List<string> Extract(string commandsSequence)
    {
        if (commandsSequence.Length < 2) return new List<string>();

        var consumedSequence = "";
        var commands = new List<string>();
        foreach (var ch in commandsSequence)
        {
            consumedSequence += ch;

            if (consumedSequence == "iz" || consumedSequence == "at" || consumedSequence == "del" ||
                consumedSequence == "der")
            {
                commands.Add(consumedSequence);
                consumedSequence = "";
            }
        }

        return commands;
    }
}