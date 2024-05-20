using System.Collections.Generic;
using System.Linq;

namespace MarsRover.communicationProtocols.commandExtractor;

public class FixedLengthCommandExtractor : CommandExtractor
{
    private readonly uint _length;

    public FixedLengthCommandExtractor(uint length)
    {
        _length = length;
    }

    public List<string> Extract(string commandsSequence)
    {
        return commandsSequence
            .Chunk((int)_length)
            .Select(arr => string.Join("", arr)).ToList();
    }
}